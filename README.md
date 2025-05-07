@startuml GemMiningGameUML

title Gem Mining Game - Class Diagram

skinparam class {
    BackgroundColor White
    BorderColor Black
    ArrowColor #444
}

package "GemMiningGame" {
    class Game {
        -player: Player
        -mine: Mine
        -merchant: Merchant
        -isRunning: bool
        +Run(): void
        -MineGems(): void
        -VisitMerchant(): void
    }

    class Player {
        -Inventory: List<Gem>
        -CurrentDrill: Drill
        -Money: decimal
        +AddToInventory(gem: Gem): void
        +SellAllGems(): decimal
        +DisplayInventory(merchant: Merchant): void
        +PurchaseDrill(drill: Drill): bool
        +FormatMoney(amount: decimal): string
    }

    class Gem {
        +Name: string
        +Value: decimal
        +Rarity: GemRarity
    }

    enum GemRarity {
        Common
        Uncommon
        Rare
        Epic
        Legendary
    }

    class Drill {
        +Name: string
        +Tier: int
        +Cost: decimal
        +RarityProbabilities: Dictionary<GemRarity, int>
    }

    class Mine {
        -random: Random
        -possibleGems: List<Gem>
        +MineGem(drill: Drill, ownsMine: bool): Gem
    }

    class Merchant {
        -allDrills: List<Drill>
        +Deed: MineDeed
        +Interact(player: Player): void
        -ShowAvailableDrills(player: Player): void
        -SellGems(player: Player): void
        -OfferDrills(player: Player): void
        -AttemptPurchaseDeed(player: Player): void
    }

    class MineDeed {
        +Name: string
        +Description: string
        +Price: decimal
        +IsPurchased: bool
        +Purchase(): void
        +GetPriceFormatted(player: Player): string
    }
}

Game "1" *-- "1" Player
Game "1" *-- "1" Mine
Game "1" *-- "1" Merchant

Player "1" *-- "0..*" Gem
Player "1" *-- "1" Drill

Mine "1" *-- "0..*" Gem
Mine "1" *-- "1" Random

Merchant "1" *-- "1" MineDeed
Merchant "1" *-- "0..*" Drill

Drill "1" *-- "1..*" GemRarity

@enduml
