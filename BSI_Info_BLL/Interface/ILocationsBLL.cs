using BSI_Info_BLL.DTO;
using System;
using System.Collections.Generic;

public interface ILocationsBLL
{
    IEnumerable<LocationsDTO> GetAllLocations();
    LocationsDTO GetLocationById(int locationId);
    void AddLocation(CreateLocationsDTO newLocation);
    void DeleteLocation(int locationId);
    void UpdateLocation(UpdateLocationsDTO updatelocation);
}

