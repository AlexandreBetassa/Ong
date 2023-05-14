namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalResponse
    {
        public Entities.Animal Animal { get; set; }

        public GetAnimalResponse(Entities.Animal animal)
        {
            Animal = animal;
        }
    }
}