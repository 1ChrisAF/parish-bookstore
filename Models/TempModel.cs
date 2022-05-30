using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

/**
* UPDATE: (see GitHub for previous note, made 29 May 2022)
* Each time an edit is made to the model, but the image is NOT
* changed, a random int "bookie" is generated. The bookie and 
* unchanged image name associated with the model are written to
* the Temp DbSet, with bookie as the ID and the string as the 
* value. When Edit POST is called, the image name string is
* retrieved from Temp, re-assigned to the model, and then the 
* now-unnecessary entry in Temp is deleted.
*/

public class TempModel
{
    public int Id { get; set; }

    public string ImageName { get; set; }
}