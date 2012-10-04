namespace app.web.application.catalogbrowsing
{
    public class ProductItem : ICanPrintItemInfo, ICanUniquelyIdentifyMyself
    {
      public string name { get; set; }

      public string FormattedString()
      {
          return name;
      }

    public string GetUniqueIdentifier()
    {
        return ToString() + "ProductItem";
    }
    }
}