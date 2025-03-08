using BlazorApp2.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

public class OrderService
{
    public List<Order> Orders { get; private set; } = new();
    public event Action OnChange;

    public void AddOrder(Property property, string userId)
    {
        // Проверяем, что недвижимость ещё не добавлена
        if (!Orders.Any(o =>
            o.UserId == userId &&
            o.Property.ID == property.ID))
        {
            Orders.Add(new Order
            {
                Property = property,
                UserId = userId
            });
            NotifyStateChanged();
        }
    }

    public void RemoveOrder(Guid orderId)
    {
        var order = Orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            Orders.Remove(order);
            NotifyStateChanged();
        }
    }

    public void ConfirmOrder(Guid orderId)
    {
        var order = Orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.IsConfirmed = true;
            NotifyStateChanged();
        }
    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();


    ///
    private readonly ApplicationDbContext _context;
    private readonly AuthenticationStateProvider _authProvider;

    public OrderService(
        ApplicationDbContext context,
        AuthenticationStateProvider authProvider)
    {
        _context = context;
        _authProvider = authProvider;
    }

    public async Task ConfirmOrderAsync(Order order)
    {
        var authState = await _authProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        var contract = new Contract
        {
            ClientEmail = user.Identity?.Name,
            PropertyID = order.Property.ID,
            ContractDate = DateTime.Now
        };

        var property = await _context.Properties
            .FirstOrDefaultAsync(p => p.ID == order.Property.ID);

        property.Status = "Продано";
        _context.Properties.Update(property);

        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();

        order.IsConfirmed = true;
    }
}

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Property Property { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string UserId { get; set; }
    public bool IsConfirmed { get; set; }
}
