using Pictures2Kml.DL.Interfaces;
using ExifLib;

namespace Pictures2Kml.DL
{
    public class Picture : IPicture
    {
        public GeoCoordinate? GetGeoLocationFromImage(string imagePath)
        {
            try
            {
                using (ExifReader reader = new ExifReader(imagePath))
                {
                    double[] latitudeLongitude = new double[2];

                    if (reader.GetTagValue<double[]>(ExifTags.GPSLatitude, out latitudeLongitude))
                    {
                        double latitude = latitudeLongitude[0] + latitudeLongitude[1] / 60 + latitudeLongitude[2] / 3600;
                        if (reader.GetTagValue<string>(ExifTags.GPSLatitudeRef, out string latitudeRef))
                        {
                            if (latitudeRef == "S")
                                latitude = -latitude;

                            double[] longitudeArray;
                            if (reader.GetTagValue<double[]>(ExifTags.GPSLongitude, out longitudeArray))
                            {
                                double longitude = longitudeArray[0] + longitudeArray[1] / 60 + longitudeArray[2] / 3600;
                                if (reader.GetTagValue<string>(ExifTags.GPSLongitudeRef, out string longitudeRef))
                                {
                                    if (longitudeRef == "W")
                                        longitude = -longitude;

                                    return new GeoCoordinate(latitude, longitude);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null; // Return null if no GPS information is found
        }
    }
}
