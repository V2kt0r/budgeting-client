﻿using Budgeting.Contracts.Services;
using Budgeting.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace Budgeting.Services
{
    public partial class AuthService : ObservableObject, IAuthService
    {
        #region Constants

        private const string RefreshTokenNameInCookies = "refresh_token";
        private const string AccessTokenNameInSecureStorage = "access_token";
        private const string RefreshTokenNameInSecureStorage = "refresh_token";
        private const int RefreshTokenMinuteDelta = 5;

        #endregion

        #region Attributes

        private readonly Config.Config _config;
        private readonly INavigationService _navigationService;
        [ObservableProperty]
        private bool _isLoggedIn = false;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public AuthService(Config.Config config, INavigationService navigationService)
        {
            _config = config;
            _navigationService = navigationService;
        }

        #endregion

        #region Public Methods

        public async Task<bool> IsUserAuthenticatedAsync()
        {
            try
            {
                ApiResponse<UserRead> currentUserResponse = await new UsersApi(_config.Configuration).GetUsersMeWithHttpInfoAsync();
                
                if (currentUserResponse.StatusCode == HttpStatusCode.OK)
                {
                    _config.CurrentUser = currentUserResponse.Data;
                    return true;
                }

                return false;
            }
            catch (ApiException e)
            {
                Debug.WriteLine("Exception when calling UsersApi.GetUsersMe: " + e.Message);
                return false;
            }
        }

        public async Task<bool> LoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginWithCredentialsAsync(string username = null, string password = null)
        {
            Debug.WriteLine("Attempting to login with credentials");
            ApiResponse<TokenPair> loginResponse = await new LoginApi(_config.Configuration).LoginForAccessTokenWithHttpInfoAsync(username: username, password: password);
            Debug.WriteLine("Login response status code: " + loginResponse.StatusCode);
            if (loginResponse.StatusCode != HttpStatusCode.OK)
            {
                switch (loginResponse.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        // Show error message
                        break;
                    case HttpStatusCode.Unauthorized:
                        // Show error message
                        break;
                    default:
                        // Show error message
                        break;
                }
                IsLoggedIn = false;
                return false;
            }

            Debug.WriteLine("Login successful");
            Debug.WriteLine("Access token: " + loginResponse.Data.AccessToken);
            var accessToken = loginResponse.Data.AccessToken.AccessToken;
            await SetAccessTokenAsync(accessToken);
            var refreshToken = loginResponse.Data.RefreshToken.AccessToken;
            Debug.WriteLine("Refresh token: " + refreshToken);
            await SetRefreshTokenAsync(refreshToken);
            IsLoggedIn = true;
            return true;
        }

        public async Task<bool> LoginWithTokenAsync()
        {
            var accessToken = await GetAccessTokenAsync();
            if (!string.IsNullOrEmpty(accessToken) && !IsTokenNearExpiration(accessToken) && await IsUserAuthenticatedAsync())
            {
                IsLoggedIn = true;
                return true;
            }

            var refreshToken = await GetRefreshTokenAsync();
            if (string.IsNullOrEmpty(refreshToken) || IsTokenExpired(refreshToken))
            {
                // Navigate to login page
                await _navigationService.NavigateToPageAsync<Views.LoginPage>();
                IsLoggedIn = false;
                return false;
            }

            await SetRefreshTokenAsync(refreshToken);
            Debug.WriteLine("Attempting to refresh access token");
            ApiResponse<TokenPair> loginResponse = await new LoginApi(_config.Configuration).RefreshAccessTokenWithHttpInfoAsync(new Token(accessToken: refreshToken, tokenType: "bearer"));
            Debug.WriteLine("Refresh token response status code: " + loginResponse.StatusCode);
            if (loginResponse.StatusCode != HttpStatusCode.OK)
            {
                switch (loginResponse.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        // Show error message
                        break;
                    case HttpStatusCode.Unauthorized:
                        // Show error message
                        break;
                    default:
                        // Show error message
                        break;
                }
                IsLoggedIn = false;
                return false;
            }

            Debug.WriteLine("Storing new access token");
            var newAccessToken = loginResponse.Data.AccessToken;
            await SetAccessTokenAsync(newAccessToken.AccessToken);
            Debug.WriteLine("Storing new refresh token");
            var newRefreshToken = loginResponse.Data.RefreshToken;
            await SetRefreshTokenAsync(newRefreshToken.AccessToken);
            Debug.WriteLine("Tokens refreshed");
            IsLoggedIn = true;
            return true;
        }

        public async Task LogoutAsync()
        {
            await new LoginApi(_config.Configuration).LogoutAsync();
            SecureStorage.Remove(AccessTokenNameInSecureStorage);
            SecureStorage.Remove(RefreshTokenNameInSecureStorage);
            IsLoggedIn = false;
        }

        #endregion

        #region Private Methods

        private static async Task<string> GetAccessTokenAsync()
        {
            return await SecureStorage.GetAsync(AccessTokenNameInSecureStorage);
        }

        private async Task<string> GetRefreshTokenAsync()
        {
            var refreshToken = await SecureStorage.GetAsync(RefreshTokenNameInSecureStorage);
            if (IsTokenNearExpiration(refreshToken))
            {
                var updateSuccessful = await LoginWithTokenAsync();
                if (!updateSuccessful)
                {
                    throw new Exception("Failed to update refresh token");
                }
                refreshToken = await SecureStorage.GetAsync(RefreshTokenNameInSecureStorage);
            }

            return refreshToken;
        }

        private static bool IsTokenNearExpiration(string token)
        {
            var expirationDate = JwtHelper.GetExpirationDate(token);
            return expirationDate + TimeSpan.FromMinutes(RefreshTokenMinuteDelta) < DateTime.UtcNow;
        }

        private static bool IsTokenExpired(string token)
        {
            var expirationDate = JwtHelper.GetExpirationDate(token);
            return expirationDate < DateTime.UtcNow;
        }

        private async Task SetAccessTokenAsync(string accessToken)
        {
            await SecureStorage.SetAsync(AccessTokenNameInSecureStorage, accessToken);
            _config.AccessToken = accessToken;
        }

        private async Task SetRefreshTokenAsync(string refreshToken)
        {
            await SecureStorage.SetAsync(RefreshTokenNameInSecureStorage, refreshToken);
            _config.RefreshToken = refreshToken;
        }

        #endregion
    }
}
