extends Node2D

#const item_manager = preload("res://src/ItemManager.gd")

@onready var signals_manager = get_node_or_null("/root/SignalsManager")
@onready var food_one_week_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer/FoodOneWeekButton")
@onready var food_two_week_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer2/FoodTwoWeeksButton")
@onready var food_four_week_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer3/FoodFourWeeksButton")
@onready var lotto_ticket_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer4/LottoTicketsButton")
@onready var newspaper_prices = get_node_or_null("TextBackground/ProductVBox/HBoxContainer5/NewsPaperButton")

@onready var global_data = get_node_or_null("/root/GlobalData")
@onready var item_manager = get_node_or_null("/root/ItemManager")

@onready var food_one_week = item_manager.get_item(item_manager.ItemRef.FOOD_ONE_WEEK)
@onready var food_two_weeks = item_manager.get_item(item_manager.ItemRef.FOOD_TWO_WEEKS)
@onready var food_four_weeks = item_manager.get_item(item_manager.ItemRef.FOOD_FOUR_WEEKS)
@onready var newspaper = item_manager.get_item(item_manager.ItemRef.NEWSPAPER)
@onready var lottery_ticket = item_manager.get_item(item_manager.ItemRef.LOTTERY_TICKET)

var THIS_SCENE_EXIT = Vector2(10,22)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	signals_manager.connect("scene_change", Callable(self, "change_scene_to_file"))
	food_one_week_prices.text = str(food_one_week.item_name, " - ", food_one_week.item_value)
	food_two_week_prices.text = str(food_two_weeks.item_name, " - ", food_two_weeks.item_value)
	food_four_week_prices.text = str(food_four_weeks.item_name, " - ", food_four_weeks.item_value)
	lotto_ticket_prices.text = str(lottery_ticket.item_name, " - ", lottery_ticket.item_value)
	newspaper_prices.text = str(newspaper.item_name, " - ", newspaper.item_value)
	setup_scene()
	
func setup_scene():
	if debug_this: print(self.name, ".setup_scene()")
	if owner == null:
		self.show()
	else:
		self.hide()

func change_scene_to_file(caller, scene_name, state):
	if debug_this: print(self.name + ".change_scene_to_file() caller ", caller, " state ", state, " scene_name ", scene_name)	
	if scene_name == self.name:
		if state == global_data.SCENE_STATE.HIDE:
			self.hide()
		else:
			updateItemPrices()
			self.show()
			
func updateItemPrices():
	food_one_week = item_manager.get_item(item_manager.ItemRef.FOOD_ONE_WEEK)
	food_two_weeks = item_manager.get_item(item_manager.ItemRef.FOOD_TWO_WEEKS)
	food_four_weeks = item_manager.get_item(item_manager.ItemRef.FOOD_FOUR_WEEKS)
	food_one_week_prices.text = str(
		food_one_week.item_name + " - " + 
		str(global_data.adjust_for_economy(food_one_week.item_value)))
	food_two_week_prices.text = str(
		food_two_weeks.item_name + " - " + 
		str(global_data.adjust_for_economy(food_two_weeks.item_value)))
	food_four_week_prices.text = str(
		food_four_weeks.item_name + " - " + 
		str(global_data.adjust_for_economy(food_four_weeks.item_value)))

#func on_done_clicked():
#	if debug_this: print(self.name + ".on_done_clicked")
#	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
#	signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
#	signals_manager.emit_signal("on_done_clicked", self.name)
#	self.hide()
