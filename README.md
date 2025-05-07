# Gem Mining Game

A C# console game where players mine gems and upgrade their drills to eventually purchase the mine deed.

## Class Diagram

```mermaid
classDiagram
    direction TB

    class Game {
        -Player player
        -Mine mine
        -Merchant merchant
        -bool isRunning
        +Run() void
        -MineGems() void
        -VisitMerchant() void
    }

    class Player {
        -List<Gem> Inventory
        -Drill CurrentDrill
        -decimal Money
        +AddToInventory(Gem gem) void
        +SellAllGems() decimal
        +DisplayInventory(Merchant merchant) void
        +PurchaseDrill(Drill drill) bool
        +FormatMoney(decimal amount) string
    }

    class Gem {
        +string Name
        +decimal Value
        +GemRarity Rarity
    }

    class GemRarity {
        <<enumeration>>
        Common
        Uncommon
        Rare
        Epic
        Legendary
    }

    class Drill {
        +string Name
        +int Tier
        +decimal Cost
        +Dictionary<GemRarity, int> RarityProbabilities
    }

    class Mine {
        -Random random
        -List<Gem> possibleGems
        +MineGem(Drill drill, bool ownsMine) Gem
    }

    class Merchant {
        -List<Drill> allDrills
        +MineDeed Deed
        +Interact(Player player) void
        -ShowAvailableDrills(Player player) void
        -SellGems(Player player) void
        -OfferDrills(Player player) void
        -AttemptPurchaseDeed(Player player) void
    }

    class MineDeed {
        +string Name
        +string Description
        +decimal Price
        +bool IsPurchased
        +Purchase() void
        +GetPriceFormatted(Player player) string
    }

    Game --> Player : manages
    Game --> Mine : contains
    Game --> Merchant : contains
    Player --> Gem : collects
    Player --> Drill : uses
    Mine --> Gem : generates
    Merchant --> Drill : sells
    Merchant --> MineDeed : offers
    Drill --> GemRarity : defines probabilities
