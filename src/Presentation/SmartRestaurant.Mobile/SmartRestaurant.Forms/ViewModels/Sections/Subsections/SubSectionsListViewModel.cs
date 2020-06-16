
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections
{
    /// <summary>
    /// Used to bind subsections liste with the View.
    /// </summary>
    public class SubSectionsListViewModel: SimpleViewModel
    {
        /// <summary>
        /// SubSections to bind with the View.
        /// </summary>
        public ObservableCollection<SubSectionViewModel> SubSections { get; set; }
        public SectionViewModel Section { get; set; }
        /// <summary>
        /// Constructor to Fill the List of subsections from the Database or Json file stored locally.
        /// </summary>
        public SubSectionsListViewModel(SectionViewModel _section)
        {
            Section = _section;
            ObservableCollection<SubSectionModel> listSubSections = SectionsService.GetListSubSections(_section.Id);
            SubSections = new ObservableCollection<SubSectionViewModel>();
            foreach (var item in listSubSections)
            {
                SubSections.Add(new SubSectionViewModel(item, _section));
            }
        }

        private SubSectionViewModel OldSubSection;
        public void HideOrShowItem(SubSectionViewModel subsection)
        {
            if (OldSubSection == subsection)
            {
                subsection.IsVisible = !subsection.IsVisible;
                UpdateSubSection(subsection);
            }
            else
            {
                if (OldSubSection != null)
                {
                    OldSubSection.IsVisible = false;
                    UpdateSubSection(OldSubSection);
                }
                subsection.IsVisible = true;
                UpdateSubSection(subsection);
            }
            OldSubSection = subsection;
        }

        public void UpdateSubSection(SubSectionViewModel subsection)
        {
            var index = SubSections.IndexOf(subsection);
            SubSections.Remove(subsection);
            SubSections.Insert(index, subsection);
        }
        /// <summary>
        /// The DishViewModel selected by the user to serve  the customer
        /// </summary>

        public TextAlignment OrientationText
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? TextAlignment.End : TextAlignment.Start;
                }
                else
                {
                    return TextAlignment.Start;
                }
            }
        }

        public FlowDirection FlowDirectionValue
        {
            
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                }
                else
                {
                    return FlowDirection.LeftToRight;
                }
            }
        }


        private SubSectionViewModel selectedSubSection;
        public SubSectionViewModel SelectedSubSection
        {
            get { return selectedSubSection; }
            set
            {
                SetPropertyValue(ref selectedSubSection, value);

            }
        }
        /// <summary>
        /// Command to navigate to the next page or view.
        /// </summary>
        public ICommand NextCommand
        {
            get
            {
                return new Command(async() => {
                    try
                    {
                        
                    }
                    catch (Exception)
                    {

                         
                    }
                });
            }
        }

    }
}
