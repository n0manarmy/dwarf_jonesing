extends Node

const item = preload("res://src/Item.gd")

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

#export var LOW_COST_RENT = "LOW_COST_RENT"
#export var LE_SECURITY_RENT = "LE_SECURITY_RENT"
#export var FOOD_ONE_WEEK = 50
#export var FOOD_TWO_WEEK = 90
#export var FOOD_FOUR_WEEK = 125
#export var NEWSPAPER = 5
#export var LOTTERY_TICKET = 10


func _init():
	self.items = [
		item.new(ItemRef.LOW_COST_RENT, "Rent Low Cost Appartment", 325, 0),
		item.new(ItemRef.LE_SECURITY_RENT, "Rent Le Security Appartment", 600, 10),
		item.new(ItemRef.FOOD_ONE_WEEK, "Food for one week", 50, 0),
		item.new(ItemRef.FOOD_TWO_WEEKS, "Food for two weeks", 90, 0),
		item.new(ItemRef.FOOD_FOUR_WEEKS, "Food for four weeks", 125, 0),
		item.new(ItemRef.NEWSPAPER, "Newspaper", 5, 0),
		item.new(ItemRef.LOTTERY_TICKET, "Lottery Ticket", 10, 0),
	]
	
func get_item(item_ref):
	for item in items:
		if item.item_ref == item_ref:
			return item

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
