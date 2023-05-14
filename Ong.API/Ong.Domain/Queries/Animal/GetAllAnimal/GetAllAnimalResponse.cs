namespace Ong.Domain.Queries.Animal.GetAllAnimal
{
    public class GetAllAnimalResponse
    {
        public IEnumerable<Entities.Animal> animais { get; set; }

        public GetAllAnimalResponse(IEnumerable<Entities.Animal> animais)
        {
            this.animais = animais;
        }
    }
}