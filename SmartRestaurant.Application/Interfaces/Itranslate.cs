namespace SmartRestaurant.Application.Interfaces
{
    public interface ITranslate
    {
        /// <summary>
        /// TableName,ColumnName,Target language
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Translate(string[] args);
    }
}
