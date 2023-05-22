namespace Ong.Domain.Queries.Animal.GetAllAnimal
{
    public class GetAllAnimalQueryResponse
    {
        public IEnumerable<Entities.Animal> animais { get; set; }

        public GetAllAnimalQueryResponse(IEnumerable<Entities.Animal> animais)
        {
            this.animais = animais;
        }
    }
}