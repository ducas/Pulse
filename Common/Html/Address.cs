using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace Common.Html
{
    public static class HtmlListHelpers
    {
        public static string AddressList(this HtmlHelper html)
        {
            return html.Kendo()
                .ListView<Address>()
                .TagName("ul")
                .ClientTemplateId("address_itemTemplate")
                .Pageable()
                .DataSource(d => d.Read(r => r.Action("IndexJson", "Addresses", new { area = "" })))
                .Selectable(b => b.Mode(ListViewSelectionMode.Single))
                .ToHtmlString();
        }
    }
}
