extends Node2D

#const item_manager = preload("res://src/ItemManager.gd")

onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var food_one_week_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer/Price")
onready var food_two_week_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer2/Price")
onready var food_four_week_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer3/Price")
onready var lotto_ticket_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer4/Price")
onready var newspaper_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer5/Price")

onready var global_data = get_node_or_null("/root/GlobalData")
onready var item_manager = get_node_or_null("/root/ItemManager")

var THIS_SCENE_EXIT = Vector2(10,22)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	signals_manager.connect("scene_change", self, "change_scene")
	food_one_week_prices.text = str(item_manager.FOOD_ONE_WEEK_BASE_VALUE)
	food_two_week_prices.text = str(item_manager.FOOD_TWO_WEEK_BASE_VALUE)
	food_four_week_prices.text = str(item_manager.FOOD_FOUR_WEEK_BASE_VALUE)
	lotto_ticket_prices.text = str(item_manager.LOTTERY_TICKET_BASE_VALUE)
	newspaper_prices.text = str(item_manager.NEWSPAPER_BASE_VALUE)
	setup_scene()
	
func setup_scene():
	if debug_this: print(self.name, ".setup_scene()")
	if owner == null:
		self.show()
	else:
		self.hide()

func change_scene(caller, scene_name, state):
	if debug_this: print(self.name + ".change_scene() caller ", caller, " state ", state, " scene_name ", scene_name)	
	if scene_name == self.name:
		if state == global_data.SCENE_STATE.HIDE:
			self.hide()
		else:
			updateItemPrices()
			self.show()
			
func updateItemPrices():
	pass

#func on_done_clicked():
#	if debug_this: print(self.name + ".on_done_clicked")
#	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
#	signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
#	signals_manager.emit_signal("on_done_clicked", self.name)
#	self.hide()
