namespace AddressAdapter
{
    public class AddressProvider
    {
        public AddressProvider(string streetName, string neighborhoodName, string city, int zipCode, int buildingNumber)
        {
            StreetName = streetName;
            NeighborhoodName = neighborhoodName;
            City = city;
            ZipCode = zipCode;
            BuildingNumber = buildingNumber;
        }

        public string StreetName { get; set; }
        public string NeighborhoodName { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public int BuildingNumber { get; set; }
    }
}