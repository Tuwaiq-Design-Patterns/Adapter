namespace AddressAdapter
{
    public class AddressAdapter : IStringAddress
    {
        private readonly AddressProvider _addressProvider;

        public AddressAdapter(AddressProvider addressProvider)
        {
            this._addressProvider = addressProvider;
        }

        public string GetAddress()
        {
            return $"City: {_addressProvider.City}\n" +
                   $"Street Name: {_addressProvider.StreetName}\n" +
                   $"Zip Code: {_addressProvider.ZipCode}\n" +
                   $"NeighborhoodName: {_addressProvider.NeighborhoodName}\n" +
                   $"Building Number: {_addressProvider.BuildingNumber}";
        }
    }
}