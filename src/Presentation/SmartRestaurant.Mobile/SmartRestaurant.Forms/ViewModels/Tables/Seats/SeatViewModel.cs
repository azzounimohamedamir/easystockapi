using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.ViewModels.Orders;
using SmartRestaurant.Diner.ViewModels.Sections;
using System.Linq;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Tables
{
    /// <summary>
    /// Used to manage tables as a ViewModel
    /// </summary>
    public class SeatViewModel : SimpleViewModel
    {
        public readonly int table_Id;
        public readonly int seat_number;
        public readonly string table_number;
        public TablesViewModel Table;
        /// <summary>
        /// Get the TableModel from the Model.
        /// </summary>
        /// <param name="_table"></param>
        public SeatViewModel(int _table_Id,int _numero,string _table_number, TablesViewModel table)
        {
            table_Id = _table_Id;
            seat_number = _numero;
            table_number = _table_number;
            var orders = SectionsListViewModel.Orders.Orders.Where(o => o.SeatNumber == seat_number && o.TableId == table_Id).ToList();
            if (orders.Count > 0)
                CurrentOrder = orders.First();
            else
            {
                CurrentOrder = new OrderViewModel(new OrderModel
                {
                    SeatId = Id,
                    TableId = table_Id,
                    SeatNumber = seat_number,
                    TableNumber = table_number
                });
                SectionsListViewModel.Orders.Orders.Add(CurrentOrder);
            }
            Table = table;
            Table.CurrentOrders.Orders.Add(CurrentOrder);
        }

        public int Id { get; }
        
        public int SeatNumber
        {
            get { return seat_number; }
            set
            {
                if (seat_number != value)
                {
                    SeatNumber = value;
                    RaisePropertyChanged();
                }
            }
        }
 
        /// <summary>
        /// Used to indicate when a seat is selected.
        /// </summary>
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            { 
                    isSelected = value;
                    RaisePropertyChanged();
                if(IsTaken)
                    BackgroundColor = Color.FromHex("#FFA374");
                else
                if (IsSelected)
                        BackgroundColor = Color.FromHex("#F2FBFB");
                    else
                        BackgroundColor = Color.White;
                RaisePropertyChanged("BackgroundColor");
                if (IsTaken)
                    BorderColor= Color.FromHex("#EEEEEE");
                else
                if (isSelected) BorderColor = Color.FromHex("#3CBDBF");
                    else
                    BorderColor = Color.FromHex("#EEEEEE");
                    RaisePropertyChanged("BorderColor");
                    
            }
        }
        private Color bordercolor;
        public Color BorderColor
        {
            get
            {                                                   
                if (IsTaken)
                    return Color.FromHex("#EEEEEE");
                else

                if (isSelected)
                    return Color.FromHex("#3CBDBF");
                else
                    return Color.FromHex("#EEEEEE");
            }
            set
            {
                if (bordercolor != value)

                    bordercolor = value;
            }
        }


        private bool isTaken;
        public bool IsTaken
        {
            get
            {
                if (!isTaken)
                    isTaken = (CurrentOrder == null || CurrentOrder.Lines==null) ? false : CurrentOrder.Lines.Count > 0;
                return isTaken;
            }
            set
            {
                isTaken = value;
                RaisePropertyChanged();
                if (isTaken)
                    BackgroundColor = Color.FromHex("#FFA374");
                else
                    if (IsSelected)
                    BackgroundColor= Color.FromHex("#F2FBFB");
                else
                    BackgroundColor= Color.White;
                RaisePropertyChanged("BackgroundColor");

            }
        }
        private Color backgroundcolor;
        public Color BackgroundColor
        {
            get
            {
                if (IsTaken)
                    return Color.FromHex("#FFA374");
                else
                    if(IsSelected)
                    return Color.FromHex("#F2FBFB");
                else
                    return Color.White;
            }
            set
            {
                if (backgroundcolor != value)

                    backgroundcolor = value;
            }
        }
        private OrderViewModel currentOrder;
        public OrderViewModel CurrentOrder
        {
            get
            {
                if (currentOrder == null) currentOrder = new OrderViewModel(new OrderModel
                {
                    SeatId = Id,
                    TableId = table_Id,
                    SeatNumber=seat_number,
                    TableNumber=table_number
                });
                return currentOrder;
            }
            set
            {
                currentOrder = value;
            }
        }
        private bool isVisible;
        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
                RaisePropertyChanged();
            }
        
        }
    }
}
