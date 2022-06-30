extends Node

const Item = preload("res://src/Item.gd")

enum ItemRef {
	LOW_COST_RENT = 0,
	LE_SECURITY_RENT = 1,
	FOOD_ONE_WEEK = 2,
	FOOD_TWO_WEEKS = 3,
	FOOD_FOUR_WEEKS = 4,
	NEWSPAPER = 5,
	LOTTERY_TICKET = 6,
}

export var items: Array
var debug_this = true

func _init():
	self.items = [
		Item.new(ItemRef.LOW_COST_RENT, "Rent Low Cost Appartment", 325, 0),
		Item.new(ItemRef.LE_SECURITY_RENT, "Rent Le Security Appartment", 600, 10),
		Item.new(ItemRef.FOOD_ONE_WEEK, "Food for one week", 50, 0),
		Item.new(ItemRef.FOOD_TWO_WEEKS, "Food for two weeks", 90, 0),
		Item.new(ItemRef.FOOD_FOUR_WEEKS, "Food for four weeks", 125, 0),
		Item.new(ItemRef.NEWSPAPER, "Newspaper", 5, 0),
		Item.new(ItemRef.LOTTERY_TICKET, "Lottery Ticket", 10, 0),
	]
	
func get_item(item_ref):
	if debug_this: print(self.name, ".get_item item_ref: ", item_ref)
	for item in items:
		if item.item_ref == item_ref:
			var this_item: Item = item
			if debug_this: print(self.name, ".this_item: ", this_item)
			return this_item

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
