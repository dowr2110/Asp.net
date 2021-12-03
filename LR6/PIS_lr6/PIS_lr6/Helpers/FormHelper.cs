using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIS_lr6.Helpers
{
    public static class FormHelper
    {
        public static MvcHtmlString AddForm(this HtmlHelper html)
        {
            TagBuilder divTag = new TagBuilder("div");
            TagBuilder inputName = new TagBuilder("input");
            TagBuilder inputPhone = new TagBuilder("input");
            TagBuilder inputSubmit = new TagBuilder("input");

            inputName.Attributes.Add("type", "text");
            inputPhone.Attributes.Add("type", "text");
            inputSubmit.Attributes.Add("type", "submit");

            inputName.Attributes.Add("name", "Surname");
            inputPhone.Attributes.Add("name", "Number");

            inputName.Attributes.Add("placeholder", "Surname");
            inputPhone.Attributes.Add("placeholder", "Number");

            inputName.Attributes.Add("value", "");
            inputPhone.Attributes.Add("value", "");
            inputSubmit.Attributes.Add("value", "Add Telephone");

            divTag.InnerHtml += inputName.ToString();
            divTag.InnerHtml += inputPhone.ToString();
            divTag.InnerHtml += inputSubmit.ToString();


            return new MvcHtmlString(divTag.ToString());
        }

        public static MvcHtmlString UpdateForm(this HtmlHelper html)
        {
            TagBuilder divTag = new TagBuilder("div");
            TagBuilder inputId = new TagBuilder("input");
            TagBuilder inputName = new TagBuilder("input");
            TagBuilder inputPhone = new TagBuilder("input");
            TagBuilder inputSubmit = new TagBuilder("input");

            inputId.Attributes.Add("type", "text");
            inputName.Attributes.Add("type", "text");
            inputPhone.Attributes.Add("type", "text");
            inputSubmit.Attributes.Add("type", "submit");

            inputId.Attributes.Add("name", "Id");
            inputName.Attributes.Add("name", "Surname");
            inputPhone.Attributes.Add("name", "Number");

            inputId.Attributes.Add("placeholder", "Id");
            inputName.Attributes.Add("placeholder", "Surname");
            inputPhone.Attributes.Add("placeholder", "Phone");

            inputId.Attributes.Add("value", "");
            inputName.Attributes.Add("value", "");
            inputPhone.Attributes.Add("value", "");
            inputSubmit.Attributes.Add("value", "Update Telephone");

            divTag.InnerHtml += inputId.ToString();
            divTag.InnerHtml += inputName.ToString();
            divTag.InnerHtml += inputPhone.ToString();
            divTag.InnerHtml += inputSubmit.ToString();


            return new MvcHtmlString(divTag.ToString());
        }
    }
}