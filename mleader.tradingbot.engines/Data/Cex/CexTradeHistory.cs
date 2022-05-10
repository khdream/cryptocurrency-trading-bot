﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace mleader.tradingbot.Data.Cex
{
    public class CexTradeHistory : ITradeHistory
    {
        /// <summary>
        /// Trade Id
        /// </summary>
        [JsonProperty("tid")]
        [DataMember(Name = "tid")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [DataMember(Name = "type")]
        public OrderType OrderType { get; set; }

        [JsonProperty("amount")]
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty("price")]
        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Date Timestamp
        /// </summary>
        [JsonProperty("date")]
        [DataMember(Name = "date")]
        public double Date { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public DateTime Timestamp
        {
            get
            {
                var convertDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                convertDateTime = convertDateTime.AddSeconds(Date).ToLocalTime();
                return convertDateTime;
            }
        }
    }
}