namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalQueryResponse
    {
        public Entities.Animal Animal { get; set; }

        public GetAnimalQueryResponse(Entities.Animal animal)
        {
            Animal = animal;
        }
    }
}