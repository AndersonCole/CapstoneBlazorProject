using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing a game
/// </summary>
public class GameModel
{
    /// <summary>
    /// Id of the game
    /// </summary>
    public int GameId { get; set; }
    /// <summary>
    /// Id of the generation the games apart of
    /// </summary>
    public int GenId { get; set; }
    /// <summary>
    /// Name of the game
    /// </summary>
    public string GameName { get; set; }
    /// <summary>
    /// Shorthand abbreviation of the game
    /// </summary>
    public string Abbreviation { get; set; }
    /// <summary>
    /// The region the game takes place in
    /// </summary>
    public string Region { get; set; }
}
