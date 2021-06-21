using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FirewallRuleManagement.Models
{
    public class Filter
    {
        public int Id { get; set; }
        public string Chain { get; set; }
        public IEnumerable<SelectListItem> ChainItems()
        {
            yield return new SelectListItem { Text = "forward", Value = "forward" };
            yield return new SelectListItem { Text = "input", Value = "input" };
            yield return new SelectListItem { Text = "output", Value = "output" };
        }
        public string Action { get; set; }
        public IEnumerable<SelectListItem> ActionItems()
        {
            yield return new SelectListItem { Text = "accept", Value = "accept" };
            yield return new SelectListItem { Text = "drop", Value = "drop" };
            yield return new SelectListItem { Text = "log", Value = "log" };
            yield return new SelectListItem { Text = "return", Value = "return" };
            yield return new SelectListItem { Text = "add-dst-to-address-list", Value = "add-dst-to-address-list" };
            yield return new SelectListItem { Text = "fasttrack-connection", Value = "fasttrack-connection" };
            yield return new SelectListItem { Text = "passthrough", Value = "passthrough" };
            yield return new SelectListItem { Text = "tarpit", Value = "tarpit" };
            yield return new SelectListItem { Text = "add-src-to-address-list", Value = "add-src-to-address-list" };
            yield return new SelectListItem { Text = "jump", Value = "jump" };
            yield return new SelectListItem { Text = "reject", Value = "reject" };

        }
        public string Comment { get; set; }
        [JsonProperty(PropertyName = "src-address")]
        public string SrcAddress { get; set; }
        [JsonProperty(PropertyName = "SrcAddress")]
        public string SrcAddress2 { set { SrcAddress = value; } }
        [JsonProperty(PropertyName= "dst-address")]
        public string DstAddress { get; set; }
        [JsonProperty(PropertyName = "DstAddress")]
        public string DstAddress2 { set { DstAddress = value; } }
        public string Protocol { get; set; }
        public IEnumerable<SelectListItem> ProtocolItems()
        {
            yield return new SelectListItem { Text = "", Value = "" };
            yield return new SelectListItem { Text = "dccp", Value = "dccp" };
            yield return new SelectListItem { Text = "ggp", Value="ggp"};
            yield return new SelectListItem { Text = "idpr-cmtp", Value = "idpr-cmtp" };
            yield return new SelectListItem { Text = "ipsec-esp", Value = "ipsec-esp" };
            yield return new SelectListItem { Text = "ipv6-route", Value = "ipv6-route" };
            yield return new SelectListItem { Text = "pup", Value = "pup" };
            yield return new SelectListItem { Text = "st", Value = "st" };
            yield return new SelectListItem { Text = "vrrp", Value = "vrrp" };
            yield return new SelectListItem { Text = "ddp", Value = "ddp" };
            yield return new SelectListItem { Text = "gre", Value = "gre" };
            yield return new SelectListItem { Text = "igmp", Value = "igmp" };
            yield return new SelectListItem { Text = "ipv6-encap", Value = "ipv6-encap" };
            yield return new SelectListItem { Text = "iso-tp4", Value = "iso-tp4" };
            yield return new SelectListItem { Text = "rdp", Value = "rdp" };
            yield return new SelectListItem { Text = "tcp", Value = "tcp" };
            yield return new SelectListItem { Text = "xns-idp", Value = "xns-idp" };
            yield return new SelectListItem { Text = "egp", Value = "egp" };
            yield return new SelectListItem { Text = "hmp", Value = "hmp" };
            yield return new SelectListItem { Text = "ipencap", Value = "ipencap" };
            yield return new SelectListItem { Text = "ipv6-frag", Value = "ipv6-frag" };
            yield return new SelectListItem { Text = "l2tp", Value = "l2tp" };
            yield return new SelectListItem { Text = "rspf", Value = "rspf" };
            yield return new SelectListItem { Text = "udp", Value = "udp" };
            yield return new SelectListItem { Text = "xtp", Value = "xtp" };
            yield return new SelectListItem { Text = "encap", Value = "encap" };
            yield return new SelectListItem { Text = "icmp", Value = "icmp" };
            yield return new SelectListItem { Text = "ipip", Value = "ipip" };
            yield return new SelectListItem { Text = "ipv6-nonxt", Value = "ipv6-nonxt" };
            yield return new SelectListItem { Text = "ospf", Value = "ospf" };
            yield return new SelectListItem { Text = "rsvp", Value = "rsvp" };
            yield return new SelectListItem { Text = "udp-lite", Value = "udp-lite" };
            yield return new SelectListItem { Text = "etherip", Value = "etherip" };
            yield return new SelectListItem { Text = "icmpv6", Value = "icmpv6" };
            yield return new SelectListItem { Text = "ipsec-ah", Value = "ipsec-ah" };
            yield return new SelectListItem { Text = "ipv6-opts", Value = "ipv6-opts" };
            yield return new SelectListItem { Text = "pim", Value = "pim" };
            yield return new SelectListItem { Text = "sctp", Value = "sctp" };
            yield return new SelectListItem { Text = "vmtp", Value = "vmtp" };
        }
        [JsonProperty(PropertyName= "src-port")]
        public string SrcPort { get; set; }
        [JsonProperty(PropertyName = "SrcPort")]
        public string SrcPort2 { set { SrcPort = value; } }
        [JsonProperty(PropertyName= "dst-port")]
        public string DstPort { get; set; }
        [JsonProperty(PropertyName = "DstPort")]
        public string DstPort2 { set { DstPort = value; } }
        [JsonProperty(PropertyName = "in-interface")]
        public string InInterface { get; set; }
        [JsonProperty(PropertyName = "InInterface")]
        public string InInterface2 { set { InInterface = value; } }
        [JsonProperty(PropertyName = "out-interface")]
        public string OutInterface { get; set; }
        [JsonProperty(PropertyName = "OutInterface")]
        public string OutInterface2 { set { OutInterface = value; } }
        [JsonProperty(PropertyName = "src-address-list")]
        public string SrcAddressList { get; set; }
        [JsonProperty(PropertyName = "SrcAddressList")]
        public string SrcAddressList2 { set { SrcAddressList = value; } }
        [JsonProperty(PropertyName = "dst-address-list")]
        public string DstAddressList { get; set; }
        [JsonProperty(PropertyName = "DstAddressList")]
        public string DstAddressList2 { set { DstAddressList = value; } }
        public IEnumerable<SelectListItem> InterfaceItems { get; set; }
        public string Limit { get; set; }
        public bool Disabled { get; set; }

    }
}
