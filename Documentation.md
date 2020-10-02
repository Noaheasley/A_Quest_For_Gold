## Design of the game

 The game's flow is based on a switch statement for each battle encounter 
along with an update loop

Characters like the enemies and player use a Character class to get their base stats like name, health, damage, and coin ammount

Enemies need to be equiped with a weapon or else they'll just do their base damage that they've been assigned in the initalization.
This allows us to have features such as disarming so that the enemy could do less damage.

# Object description

### Game Class
     Name: _gameOver
             Description: determines if the game has ended or not
             Type:bool
     Name: Run()
             Description: runs the game
             Type:void
     Name: Start()
             Description:opens the start menu and initalizes all the characters and items
             Type:void
     Name: GetInput()
             Description: takes a player's input
             Type: void
     Name: Save()
             Description: saves data into a file named "SaveData.txt"
             Type:void
     Name: Load()
             Description: loads up the inital player
             Type:void
     Name: PrintShopInv(Item[] inventory)
             Description:prints out all the items in the shop's inventory
             Type:void
     Name: PrintPlayerInv(Item[] inventory)
             Description: prints the items in the players inventory
             Type:void
     Name: OpenShopMenu()
             Description:opens the shop's menu to allow players to select items that they want to buy
             Type:void
     Name: OpenMainMenu()
             Description: opens the start menu where the player can create a new character or open a save
             Type:void
     Name: CreateCharacter(ref Player player)
             Description: asks for player to enter their name before they start the initialization of the player's stats
             Type:void
     Name: startBattle(Player player, Enemy enemy)
             Description: starts a battle loop between the player and an enemy
             Type:bool
     Name: InitalizeCharacters()
             Description: Initalizes the enemies and equips them with weapons
             Type:void
     Name: InitalizeItem()
             Description:initalizes all items in the game 
             Type:void
     Name: Traverse(int roomNum)
             Description: funtion for each enemy encounters that the player will face
             Type:void
     Name: GiveBasicLoadout
             Description: inserts three items in the player's inventory 
             Type:void
     Name: SwitchWeapons(Players player)
             Description: lets the player switch their current weapon to give a different stat boost
             Type:void
     Name: Update()
             Description: area where you place all functions that involve gameplay
             Type:void
     Name: End()
             Description: displays ending text letting the player know that they've completed the game
             Type:void

### Character Class
     Name: _health
             Description: health of a character
             Type:float
     Name: _damage
             Description: base damage that a character does
             Type:float
     Name: _name_
             Description: name of the character
             Type:string
     Name: Attack(Character enemy)
             Description: allows a character to damage another character's health, requires the take damage function
             Type:virtual float
     Name: GetDamage()
             Description: returns _damage to be used anywhere outside Character Class
             Type:float
     Name: TakeDamage(float damageVal)
             Description: allows the character to take damage
             Type:virtual float
     Name: Save(StreamReader reader)
             Description: saves all of the character's stats when the save function is called
             Type: virtual void
     Name: Load(StreamReader reader)
             Description: loads in character stats once called
             Type: virtual bool
     Name: GetName()
             Description: returns _name
             Type:string
     Name: GetIsAlive()
             Description:checks if a character has died
             Type:bool
     Name: GetIsAlive(bool alive=false)
             Description: used to stop a loop if a character has died
             Type:bool
     Name: PrintStats()
             Description: prints the stats of characters
             Type:void
     Name: PrintPlayerStats(Player player)
             Description: prints the player stats
             Type:void
### Player Class
     Name: _gold
             Description: gold that is in the player's inventory
             Type:float
     Name: _inventory
             Description: inventory index of the player
             Type:Item[]
     Name: _currentWeapon
             Description: equipped weapon that the player is using which allows them to have a stat boost from a weapon that they are using
             Type:Item
     Name: _hands
             Description: used to allow the player to unequip their weapon
             Type:Item
     Name: Player(string nameVal, float healthVal, float damageVal, int inventorySize, float coinVal): base( nameVal, healthVal, damageVal, coinVal)
             Description:player constructor
             Type:Player
     Name: UnequipItem()
             Description: unequips the player's weapon 
             Type:void
     Name: GetTrueDamage
             Description: returns the ammount of damage that the player does with an equiped weapon
             Type:float
     Name: Contains(int itemIndex)
             Description: used for the player to place an item in their inventory
             Type:bool
     Name: AddItemToInv(Item item, int index)
             Description: adds an item in the inventory index
             Type:void
     Name: EquipItem(int itemIndex)
             Description: makes the player equip an item and gain it's statboost
             Type:void
     Name: Buy(Item item, int inventoryIndex)
             Description: spends the player's gold to gain an item(used in the shop's Sell function)
             Type:bool
     Name: GoldGain(Player player, Enemy enemy)
             Description: allows the player to gain gold after slaying an enemy
             Type:void
     Name: Attack(Character enemy)
             Description: allows the player to attack a character with a statboost
             Type:override float
     Name: GetInv()
             Description: returns the player inventory 
             Type:Item[]

### Shop Class
     Name: _gold
             Description: the shops gold
             Type:int
     Name: _inventory
             Description: inventory index of the shop
             Type:Item[]
     Name: Shop(Item[] items)
             Description: constructor for shops
             Type:Shop
     Name: Sell(Player player, int itemIndex, int playerIndex)
             Description: sends items that the player bought to the player's inventory index
             Type:bool

### Enemy Class
     Name: _currentWeapon
             Description: used to give the enemy a stat boost 
             Type:Item
     Name: _inventory
             Description: inventory of the enemy character
             Type:Item[]
     Name: _gold
             Description: gold in the enemies inventory
             Type:float
     Name: Enemy( string nameVal, float healthVal, int damageVal, int inventorySize, float coinVal): base( nameVal, healthVal, damageVal, coinVal)
             Description: Constructor of the Enemy Class
             Type:Enemy
     Name: EnemyAttack(Character enemy)
             Description: allows the enemy to damage a character with their weapon statboost
             Type:float
     Name: GetEnemyInv()
             Description: returns the enemy's inventory
             Type:Item[]
     Name: EnemyEquipItem(int itemIndex)
             Description: equips an enemy with a weapon to give them a stat boost
             Type:void
     Name: AddItemToInv(Item item, int index)
             Description: adds an item to the inventory of the inventory
             Type:void
     Name: Contains(int itemIndex)
             Description: used to contain an enemy weapon
             Type: bool