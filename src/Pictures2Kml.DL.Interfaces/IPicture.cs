namespace Pictures2Kml.DL.Interfaces
{
    public interface IPicture
    {
        GeoCoordinate? GetGeoLocationFromImage(string imagePath);
        
    }
}
