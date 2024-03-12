using System;
using System.Collections.Generic;
using BSI_Info_Apps;
using DAL;

public class LocationsBLL : ILocationsBLL
{
    private readonly ILocations _locationsDAL;
    public LocationsBLL()
    {
        _locationsDAL = new LocationsDAL();
    }

    public void DeleteLocation(int locationId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LocationsDTO> GetAllLocations()
    {
        try
        {
            var locations = _locationsDAL.GetAllLocations();
            var locationsDTOs = new List<LocationsDTO>();

            foreach (var locationsObj in locations)
            {
                var locationsdto = new LocationsDTO
                {
                    location_id = locationsObj.location_id,
                    name = locationsObj.name,
                    address = locationsObj.address,
                    capacity = locationsObj.capacity,
                    description = locationsObj.description,

                };

                locationsDTOs.Add(locationsdto);
            }

            return locationsDTOs;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }

    public LocationsDTO GetLocationById(int locationId)
    {
        throw new NotImplementedException();
    }

    public void UpdateLocation(LocationsDTO location)
    {
        throw new NotImplementedException();
    }

    void ILocationsBLL.AddLocation(CreateLocationsDTO createLocations)
    {
        try
        {
            var location = new Locations
            {
                name = createLocations.name,
                address = createLocations.address,
                capacity = createLocations.capacity,
                description = createLocations.description,
            };

            if (createLocations != null)
            {
                _locationsDAL.InsertLocation(location);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }
}


    