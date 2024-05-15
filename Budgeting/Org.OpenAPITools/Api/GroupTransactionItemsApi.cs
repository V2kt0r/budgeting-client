/*
 * Budgeting Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Client.Auth;
using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGroupTransactionItemsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get Group Transaction Items
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PaginatedListResponseTransactionItemReadWithTransactionData</returns>
        PaginatedListResponseTransactionItemReadWithTransactionData GetGroupTransactionItems(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0);

        /// <summary>
        /// Get Group Transaction Items
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PaginatedListResponseTransactionItemReadWithTransactionData</returns>
        ApiResponse<PaginatedListResponseTransactionItemReadWithTransactionData> GetGroupTransactionItemsWithHttpInfo(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGroupTransactionItemsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get Group Transaction Items
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PaginatedListResponseTransactionItemReadWithTransactionData</returns>
        System.Threading.Tasks.Task<PaginatedListResponseTransactionItemReadWithTransactionData> GetGroupTransactionItemsAsync(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Group Transaction Items
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PaginatedListResponseTransactionItemReadWithTransactionData)</returns>
        System.Threading.Tasks.Task<ApiResponse<PaginatedListResponseTransactionItemReadWithTransactionData>> GetGroupTransactionItemsWithHttpInfoAsync(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGroupTransactionItemsApi : IGroupTransactionItemsApiSync, IGroupTransactionItemsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class GroupTransactionItemsApi : IGroupTransactionItemsApi
    {
        private Org.OpenAPITools.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTransactionItemsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GroupTransactionItemsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTransactionItemsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GroupTransactionItemsApi(string basePath)
        {
            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                new Org.OpenAPITools.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTransactionItemsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public GroupTransactionItemsApi(Org.OpenAPITools.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTransactionItemsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public GroupTransactionItemsApi(Org.OpenAPITools.Client.ISynchronousClient client, Org.OpenAPITools.Client.IAsynchronousClient asyncClient, Org.OpenAPITools.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Org.OpenAPITools.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Org.OpenAPITools.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Org.OpenAPITools.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Org.OpenAPITools.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get Group Transaction Items 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>PaginatedListResponseTransactionItemReadWithTransactionData</returns>
        public PaginatedListResponseTransactionItemReadWithTransactionData GetGroupTransactionItems(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0)
        {
            Org.OpenAPITools.Client.ApiResponse<PaginatedListResponseTransactionItemReadWithTransactionData> localVarResponse = GetGroupTransactionItemsWithHttpInfo(groupUuid, before, after, page, itemsPerPage, tagNames, purchaseCategoryUuid);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Group Transaction Items 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of PaginatedListResponseTransactionItemReadWithTransactionData</returns>
        public Org.OpenAPITools.Client.ApiResponse<PaginatedListResponseTransactionItemReadWithTransactionData> GetGroupTransactionItemsWithHttpInfo(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0)
        {
            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (before != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "before", before));
            }
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (itemsPerPage != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "items_per_page", itemsPerPage));
            }
            localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "group_uuid", groupUuid));
            if (tagNames != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("multi", "tag_names", tagNames));
            }
            if (purchaseCategoryUuid != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "purchase_category_uuid", purchaseCategoryUuid));
            }

            localVarRequestOptions.Operation = "GroupTransactionItemsApi.GetGroupTransactionItems";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2PasswordBearer) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<PaginatedListResponseTransactionItemReadWithTransactionData>("/api/v1/group/{group_uuid/transaction-items", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroupTransactionItems", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Group Transaction Items 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PaginatedListResponseTransactionItemReadWithTransactionData</returns>
        public async System.Threading.Tasks.Task<PaginatedListResponseTransactionItemReadWithTransactionData> GetGroupTransactionItemsAsync(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Org.OpenAPITools.Client.ApiResponse<PaginatedListResponseTransactionItemReadWithTransactionData> localVarResponse = await GetGroupTransactionItemsWithHttpInfoAsync(groupUuid, before, after, page, itemsPerPage, tagNames, purchaseCategoryUuid, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Group Transaction Items 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupUuid"></param>
        /// <param name="before">Get transactions before this date (optional)</param>
        /// <param name="after">Get transactions after this date (optional)</param>
        /// <param name="page"> (optional, default to 1)</param>
        /// <param name="itemsPerPage"> (optional, default to 10)</param>
        /// <param name="tagNames">List of tag names to filter transactions by (optional)</param>
        /// <param name="purchaseCategoryUuid"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PaginatedListResponseTransactionItemReadWithTransactionData)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<PaginatedListResponseTransactionItemReadWithTransactionData>> GetGroupTransactionItemsWithHttpInfoAsync(Guid groupUuid, DateTime? before = default(DateTime?), DateTime? after = default(DateTime?), int? page = default(int?), int? itemsPerPage = default(int?), List<string>? tagNames = default(List<string>?), Guid? purchaseCategoryUuid = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (before != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "before", before));
            }
            if (after != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "after", after));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (itemsPerPage != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "items_per_page", itemsPerPage));
            }
            localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "group_uuid", groupUuid));
            if (tagNames != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("multi", "tag_names", tagNames));
            }
            if (purchaseCategoryUuid != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "purchase_category_uuid", purchaseCategoryUuid));
            }

            localVarRequestOptions.Operation = "GroupTransactionItemsApi.GetGroupTransactionItems";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2PasswordBearer) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<PaginatedListResponseTransactionItemReadWithTransactionData>("/api/v1/group/{group_uuid/transaction-items", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroupTransactionItems", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
