using GalaSoft.MvvmLight.Command;
using SmartRestaurant.Forms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.ViewModels
{
    public class OrdersViewModel : BaseViewModel 
    {
        #region Fields 
        public string Name { get; set; }
        public List<BaseImageModelDto> Images { get; set; }
        public List<IngredientModelDto> Ingredients { get; set; }
        public string INGSTR { get; set; }
        public DishNutrritionModelDto Nutrrition { get; set; }
        #endregion
        #region TestField
        private List<RotatorModel> ImageCollection = new List<RotatorModel>();
        
        #endregion

        public ICommand ShowAndHideCommand { get; set; }
        public bool headvisible { get; set; }
        public bool mainvisible { get; set; }
  

        public ObservableCollection<IngrediantModel> IngrediantItems { get; set; }
        public ObservableCollection<TemplateModel> menulist { get; set; }
        //public ObservableCollection<OrderState> ItemsList { get; set; }

        public OrdersViewModel( MenuItemModelDto menuItemModelDto)
        {
            //// mapper
            this.Images = menuItemModelDto.Images;
            this.Name = menuItemModelDto.Name;
            this.Ingredients = menuItemModelDto.Ingredients;
            this.INGSTR = menuItemModelDto.INGSTR;
            this.Nutrrition = menuItemModelDto.Nutrrition;

            //images 
            ImageCollection.Add(new RotatorModel("Meal.png"));
            ImageCollection.Add(new RotatorModel("chef.png"));
            ImageCollection.Add(new RotatorModel("Meal.png"));
            ImageCollection.Add(new RotatorModel("chef.png"));
            ImageCollection.Add(new RotatorModel("Meal.png"));


            //ItemsList = GenerateList();
            menulist = new ObservableCollection<TemplateModel>()
            {
                new TemplateModel{ Title = "Dobara" , Price="45412 DZ" , Rating =4},
                new TemplateModel{ Title = "Chorba" , Price="45412 DZ", Rating =3.5},
                new TemplateModel{ Title = "Jilbana" , Price="45412 DZ", Rating =2},
                new TemplateModel{ Title = "Coskouse", Price="45412 DZ", Rating =5 },
                new TemplateModel{ Title = "Mthoume" , Price="45412 DZ", Rating =4.5},
            };

            InitailObjects(); 
            ShowAndHideCommand = new RelayCommand(ShowAndHide);
            IngrediantItems = new ObservableCollection<IngrediantModel>()
            {
                new IngrediantModel { IngrediantName="Peper" , IsInDish=true , Quentity="2" ,Units="g"},
                new IngrediantModel { IngrediantName="Meat" , IsInDish=true , Quentity="20" ,Units="g"},
                new IngrediantModel { IngrediantName="Salt" , IsInDish=true , Quentity="0.2" ,Units="g"},
                new IngrediantModel { IngrediantName="Potatos" , IsInDish=true , Quentity="2" ,Units="g"},
                new IngrediantModel { IngrediantName="Cheese" , IsInDish=false , Quentity="2" ,Units="g"},
                new IngrediantModel { IngrediantName="Olive Oil" , IsInDish=false , Quentity="2" ,Units="g"},
                new IngrediantModel { IngrediantName="Tomatos" , IsInDish=true , Quentity="20" ,Units="g"},
            };

    
    }

        private void InitailObjects()
        {
            headvisible = false;
            mainvisible = true; 
        }

        public void ShowAndHide()
        {
           
           
         headvisible = !headvisible;
          
        }
        //public ObservableCollection<OrderState> GenerateList()
        //{
        //    //var list = new ObservableCollection<OrderState>();
        //    //for (int i = 0; i < 20; i++)
        //    //{
        //    //    var order = new OrderState
        //    //    {
        //    //        ItemName = "dobara" + i.ToString(),

        //    //        ItemTime = "500",
        //    //        Item_Status = "Waiting",


        //    //        ItemPrice = "120",



        //    //    };
        //    //    list.Add(order);
        //    //}
        //    return list;
        //}


      


    }

    public class RotatorModel
    {
        public RotatorModel(string imageString)
        {
            Image = imageString;
        }
        private String _image;
        public String Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
