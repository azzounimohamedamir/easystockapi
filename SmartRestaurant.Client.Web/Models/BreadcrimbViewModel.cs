using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models
{
    //Breadcrumb
    public class BreadcrumbItemViewModel
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }

    }

    public class BreadcrumbViewModel
    {
        public BreadcrumbViewModel()
        {
            Items = new HashSet<BreadcrumbItemViewModel>();
        }
        public Controller Controller { get; set; }
        public string Title { get; private set; }

        public ICollection<BreadcrumbItemViewModel> Items { get; private set; }

        public BreadcrumbViewModel SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public BreadcrumbViewModel AddHome()
        {
            Items.Add(new BreadcrumbItemViewModel
            {
                Text = "Home",
                Url = Controller.Url.Action("Index", "Home"),
                IsActive = false
            });
            return this;
        }

        public BreadcrumbViewModel AddItem(string text)
        {
            Items.Add(new BreadcrumbItemViewModel
            {
                Text = text,
                Url = null,
                IsActive = true
            });
            return this;
        }

        public BreadcrumbViewModel AddItem(string text, string url)
        {
            Items.Add(new BreadcrumbItemViewModel
            {
                Text = text,
                Url = url,
                IsActive = false
            });
            return this;
        }

        public BreadcrumbViewModel AddOptionalItem(string text, string url)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Items.Add(new BreadcrumbItemViewModel
                {
                    Text = text,
                    Url = url,
                    IsActive = false
                });
            }
            return this;
        }

        //[ObsoleteAttribute("De ne pas utiliser cette méthode, elle est remplacer par AddItem(text,url)")]
        //public BreadcrumbViewModel AddItem(string text,string url, bool isActive)
        //{
        //    Items.Add(new BreadcrumbItemViewModel
        //    {
        //        Text = text,
        //        Url=url,
        //        IsActive=isActive
        //    });
        //    return this;
        //}

        public void Save()
        {
            this.Controller.ViewBag.AppBreadcrumb = this;
        }
    }
}
