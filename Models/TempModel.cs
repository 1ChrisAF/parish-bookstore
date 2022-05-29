using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

/**
* I am not entirely pleased with this, but this is the best I've got
* so far. 
*
* I was having trouble with the Edit View of the Book (and thus others)
* model. If an image already exists for the Book, the page will still
* require that a new image be submitted, even if it's just a copy of
* the existing image. Making the field nullable was not satisfactory, 
* as the page would still just return NULL values for ImageName, 
* disassociating the Book from its image. I had some trouble coming up
* with a way to force the Book ImageName to persist when an image 
* isn't uploaded as part of the Edit, and this is working right now.
* Whenever Edit GET is called, a copy of the Book's ImageName is
* written to the TempModel db, with Id = 1. Then, when the Edit POST
* method is called, if the image wasn't updated, the string stored in 
* TempModel[1] is written  back into the Book's ImageName so that 
* its association with its image is not lost. This doesn't create a 
* duplicate image either, so local storage doesn't get clogged.
*
* !!!OBVIOUSLY!!!, this would not survive two people editing two
* entries at the same time, but given that this is for a small parish
* bookstore, such a scenario is not likely to materialize. 
*
* Given my experience with users, though, and their odd skill at 
* instantiating the exact bug one thought could never happen, I will
* tie up this loose end, and also because I am not content with such
* a loose end existing, on principle.
*
* This stands for now, but will be changed.
*/

public class TempModel
{
    public int Id { get; set; }

    public string ImageName { get; set; }
}