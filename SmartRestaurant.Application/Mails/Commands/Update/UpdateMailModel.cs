using SmartRestaurant.Application.Mails.Commands.Create;

namespace SmartRestaurant.Application.Mails.Commands.Update
{
    public class UpdateMailingModel : CreateMailingModel, IUpdateMailingModel
    {
        public string Id { get; set; }


    }
}