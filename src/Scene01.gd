extends Node2D

onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var im = get_node("/root/InventoryManager")
onready var global_data = get_node("/root/GlobalData")
onready var text_manager = get_node("/root/TextManager")
onready var player
onready var info_label_box: Label = get_node("TextBackground/VBoxContainer/HBoxContainer/InfoLabelBox")
onready var rest_button: Button = get_node("TextBackground/RestButton") 

var THIS_SCENE_EXIT = Vector2(31, 11)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	
	self.player = global_data.get_current_player()
	setup_buttons()

	pass # Replace with function body.
	
func setup_buttons():
	if debug_this: print(self.name + ".setup_buttons")	

	if self.player.possessions.has(im.LOW_COST_APARTMENT.keys()[0]):
		info_label_box.text = text_manager.get_random_message(text_manager.LOW_COST_APARTMENT_GREET)
		rest_button.visible = true
	else:
		rest_button.visible = false
	
func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("update_position", travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
	signals_manager.emit_signal("on_done_clicked")
	self.hide()

func on_rest_button_pressed():
	if debug_this: print(self.name + ".on_rest_clicked")
	signals_manager.emit_signal("on_rest_button_pressed", Vector2(1, 30))
