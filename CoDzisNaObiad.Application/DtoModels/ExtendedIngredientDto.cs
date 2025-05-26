namespace CoDzisNaObiad.Application.DtoModels
{
    
    // nie rób generycznego folderu DTOModels. On szybko puchnie i trudno coś w nim znaleźć.
    // Wrzuć modele które przychodzą z zewnętrzego api, obok clienta zewnętrznego api
    // Modele, które zwracasz z Query, wrzuć obok Query
    // Modele, które zwracasz z Controllera, wrzuć obok Controllera
    
    
    public class ExtendedIngredientDto
    {
        public string ProviderId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
    }
}
