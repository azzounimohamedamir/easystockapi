using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web
{
    public class PrefixConvention : IApplicationModelConvention
    {
        private AttributeRouteModel prefix;
        private AttributeRouteModel culturePrefix;
        private AttributeRouteModel restaurantPrefix;
        private AttributeRouteModel routeWithController;
        private AttributeRouteModel cultureRouteWithController;
        private AttributeRouteModel cultureRestaurantRouteWithController;

        public PrefixConvention()
        {
            //These are meant to be combined with existing route attributes
            prefix = new AttributeRouteModel(
                new RouteAttribute("/"));

            culturePrefix = new AttributeRouteModel(
                new RouteAttribute("{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/"));

            restaurantPrefix = new AttributeRouteModel(
                new RouteAttribute("{restaurant}/"));


            //These are meant to be added as routes for api controllers that do not specify any route attribute
            routeWithController = new AttributeRouteModel(
                new RouteAttribute("[controller]"));

            cultureRouteWithController = new AttributeRouteModel(
                new RouteAttribute("{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/[controller]"));

            cultureRestaurantRouteWithController = new AttributeRouteModel(
                new RouteAttribute("{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/{restaurant}/[controller]"));

        }

        private void ApplyControllerConvention(ControllerModel controller)
        {
            //Remove the "Api" suffix from the controller name 
            //The "Controller" suffix is already removed by default conventions
            //controller.ControllerName =
            //    controller.ControllerName.Substring(0, controller.ControllerName.Length - 3);

            //Either update existing route attributes or add new ones
            if (controller.Selectors.Any(x => x.AttributeRouteModel != null))
            {
                AddPrefixesToExistingRoutes(controller);
            }
            else
            {
                AddNewRoutes(controller);
            }
        }
        private void AddPrefixesToExistingRoutes(ControllerModel controller)
        {
            foreach (var selectorModel in controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList())
            {
                var originalAttributeRoute = selectorModel.AttributeRouteModel;
                //Merge controller selector with the api prefix
                selectorModel.AttributeRouteModel =
                    AttributeRouteModel.CombineAttributeRouteModel(prefix,
                        originalAttributeRoute);

                //Add another selector with the culture api prefix
                var cultureSelector = new SelectorModel(selectorModel);
                cultureSelector.AttributeRouteModel =
                    AttributeRouteModel.CombineAttributeRouteModel(culturePrefix,
                        originalAttributeRoute);
                controller.Selectors.Add(cultureSelector);

                //Add another selector with the culture and restaurant prefix
                var restaurantSelector = new SelectorModel(selectorModel);
                restaurantSelector.AttributeRouteModel =
                    AttributeRouteModel.CombineAttributeRouteModel(restaurantPrefix,
                        originalAttributeRoute);

                controller.Selectors.Add(cultureSelector);
            }
        }

        private void AddNewRoutes(ControllerModel controller)
        {
            //The controller has no route attributes, lets add a default api convention 
            var defaultSelector = controller.Selectors.First(s => s.AttributeRouteModel == null);
            defaultSelector.AttributeRouteModel = routeWithController;
            //Lets add another selector for the api with culture convention
            controller.Selectors.Add(
                new SelectorModel { AttributeRouteModel = cultureRouteWithController });
        }
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)//.Where(c => c.ControllerName.EndsWith("Api")
            {
                ApplyControllerConvention(controller);
            }
        }
    }
}
