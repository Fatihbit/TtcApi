using TtcApi.Models;

public interface ITerminalRepository
{
    Task<Terminal> GetTerminalByEmailAsync(string email);
    Task<IEnumerable<Terminal>> GetTerminalsAsync();
    Task<Terminal> GetTerminalAsync(string terminalName);
    Task AddTerminalAsync(Terminal terminal);
    Task UpdateTerminalAsync(Terminal terminal);
    Task DeleteTerminalAsync(string terminalName);
}
