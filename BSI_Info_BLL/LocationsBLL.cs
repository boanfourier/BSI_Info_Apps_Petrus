using System;
using System.Collections.Generic;
using BSI_Info_Apps;
using BSI_Info_BLL.DTO;
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
        _locationsDAL.DeleteLocation(locationId);
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
        try
        {
            var locations = _locationsDAL.GetLocationById(locationId);
            var locationdto = new LocationsDTO
            {
                location_id = locations.location_id,
                name = locations.name,
                address = locations.address,
                capacity = locations.capacity,
                description = locations.description,

            };

            return locationdto;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }

    public void UpdateLocation(UpdateLocationsDTO updatelocation)
    {
        try
        {
            var locations = new Locations
            {
                location_id = updatelocation.location_id,
                name = updatelocation.name,              
                address = updatelocation.address,
                capacity = updatelocation.capacity,
                description = updatelocation.description,
            };

            if (updatelocation != null)
            {
                _locationsDAL.UpdateLocation(locations);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
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


    