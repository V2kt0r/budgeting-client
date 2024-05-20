/*
 * Budgeting Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.3
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// TransactionCreate
    /// </summary>
    [DataContract(Name = "TransactionCreate")]
    public partial class TransactionCreate : IValidatableObject
    {

        /// <summary>
        /// Currency of the transaction.
        /// </summary>
        /// <value>Currency of the transaction.</value>
        [DataMember(Name = "currency", IsRequired = true, EmitDefaultValue = true)]
        public Currency Currency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionCreate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransactionCreate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionCreate" /> class.
        /// </summary>
        /// <param name="timestamp">Timestamp must be a valid datetime..</param>
        /// <param name="amount">Value of the transaction. (required).</param>
        /// <param name="currency">Currency of the transaction. (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="description">description (required).</param>
        /// <param name="purchaseCategoryUuid">purchaseCategoryUuid.</param>
        /// <param name="tagNames">List of tags associated with the transaction..</param>
        /// <param name="transactionItems">List of items associated with the transaction..</param>
        public TransactionCreate(DateTime timestamp = default(DateTime), decimal amount = default(decimal), Currency currency = default(Currency), string name = default(string), string description = default(string), Guid? purchaseCategoryUuid = default(Guid?), List<string> tagNames = default(List<string>), List<TransactionItemCreate> transactionItems = default(List<TransactionItemCreate>))
        {
            this.Amount = amount;
            this.Currency = currency;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for TransactionCreate and cannot be null");
            }
            this.Name = name;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for TransactionCreate and cannot be null");
            }
            this.Description = description;
            this.Timestamp = timestamp;
            this.PurchaseCategoryUuid = purchaseCategoryUuid;
            this.TagNames = tagNames;
            this.TransactionItems = transactionItems;
        }

        /// <summary>
        /// Timestamp must be a valid datetime.
        /// </summary>
        /// <value>Timestamp must be a valid datetime.</value>
        [DataMember(Name = "timestamp", EmitDefaultValue = false)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Value of the transaction.
        /// </summary>
        /// <value>Value of the transaction.</value>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets PurchaseCategoryUuid
        /// </summary>
        [DataMember(Name = "purchase_category_uuid", EmitDefaultValue = true)]
        public Guid? PurchaseCategoryUuid { get; set; }

        /// <summary>
        /// List of tags associated with the transaction.
        /// </summary>
        /// <value>List of tags associated with the transaction.</value>
        [DataMember(Name = "tag_names", EmitDefaultValue = false)]
        public List<string> TagNames { get; set; }

        /// <summary>
        /// List of items associated with the transaction.
        /// </summary>
        /// <value>List of items associated with the transaction.</value>
        [DataMember(Name = "transaction_items", EmitDefaultValue = false)]
        public List<TransactionItemCreate> TransactionItems { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransactionCreate {\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  PurchaseCategoryUuid: ").Append(PurchaseCategoryUuid).Append("\n");
            sb.Append("  TagNames: ").Append(TagNames).Append("\n");
            sb.Append("  TransactionItems: ").Append(TransactionItems).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Amount (decimal) minimum
            if (this.Amount < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Amount, must be a value greater than or equal to 0.", new [] { "Amount" });
            }

            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 100.", new [] { "Name" });
            }

            // Description (string) maxLength
            if (this.Description != null && this.Description.Length > 500)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 500.", new [] { "Description" });
            }

            yield break;
        }
    }

}
