extends Node2D

onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var im = get_node("/root/InventoryManager")
onready var global_data = get_node("/root/GlobalData")
onready var text_manager = get_node("/root/TextManager")
onready var info_label_box: Label = get_node("TextBackground/VBoxContainer/HBoxContainer/InfoLabelBox")
onready var rest_button: Button = get_node("TextBackground/RestButton")
onready var info_scene = get_node("/root/RootScene/TravelPath/InfoScene")

var THIS_SCENE_EXIT = Vector2(31, 11)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	signals_manager.connect("scene_change", self, "change_scene")
	self.hide()


func change_scene(caller, scene_name, state):
	if debug_this: print(self.name + ".change_scene() caller ", caller, " state ", state, " scene_name ", scene_name)	
	if scene_name == self.name:
		if state == info_scene.SCENE_STATE.HIDE:
			self.hide()
		else:
			self.show()
	
func setup_buttons():
	if debug_this: print(self.name + ".setup_buttons")	
	self.player = global_data.get_current_player()

	if self.player.possessions.has(im.LOW_COST_APARTMENT.keys()[0]):
		info_label_box.text = text_manager.get_random_message(text_manager.LOW_COST_APARTMENT_HOME_GREET)
		rest_button.visible = true
	else:
		info_label_box.text = text_manager.get_random_message(text_manager.LOW_COST_APARTMENT_VISITOR_GREET)
		rest_button.visible = false
	
func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
	signals_manager.emit_signal("on_done_clicked", self.name)
	self.hide()


func on_rest_button_pressed():
	if debug_this: print(self.name + ".on_rest_clicked")
	signals_manager.emit_signal("on_rest_button_pressed", self.name, {"happiness_increase": 1, "time_used": 30} )
