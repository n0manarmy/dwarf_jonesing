extends Node2D

onready var global_data = get_node_or_null("/root/GlobalData")
onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var item_manager = get_node("/root/ItemManager")
onready var text_manager = get_node("/root/TextManager")
onready var work_button = get_node_or_null("HBoxContainer/HBoxContainer/WorkButton")
onready var rest_button = get_node_or_null("HBoxContainer/HBoxContainer/RestButton")

var SCENE_01_EXIT = Vector2(31, 11)
var SCENE_02_EXIT = Vector2(42,12)
var SCENE_11_EXIT = Vector2(10,22)

var debug_this = true

# Called when the node enters the scene tree for the first time.
func _ready():
	if debug_this: print(self.name, "._ready()")
	signals_manager.connect("scene_change", self, "change_scene")
	setup_scene()
	
	
func setup_scene():
	if debug_this: print(self.name, ".setup_scene()")
	if owner == null:
		work_button.show()
		rest_button.show()
	else:
		work_button.hide()
		rest_button.hide()


func change_scene(caller, scene_name, state):
	if debug_this: print(self.name + ".change_scene() caller ", caller, " state ", state, " scene_name ", scene_name)
	var player = global_data.get_current_player()
	var owner_name = owner.name.to_lower()
	if debug_this: print(self.name, ".owner.name.to_lower(): ", owner.name.to_lower())

#	if state == global_data.SCENE_STATE.HIDE && owner_name == scene_name.to_lower():
	if state == global_data.SCENE_STATE.HIDE:
		self.hide()
		work_button.hide()
		rest_button.hide()
	if state == global_data.SCENE_STATE.SHOW:
		if debug_this: print("player.current_job.scene ", player.current_job.scene, " owner_name ", owner_name)
		if debug_this: print("self.show()")		
		self.show()
		if player.current_job.scene == owner_name:
			if debug_this: print("work_button.show()")
			work_button.show()
		if player.possessions.has(item_manager.get_item(item_manager.ItemRef.LOW_COST_RENT)) && scene_name == "Scene01":
#			info_label_box.text = text_manager.get_random_message(text_manager.LOW_COST_APARTMENT_HOME_GREET)
			rest_button.show()
		else:
#			info_label_box.text = text_manager.get_random_message(text_manager.LOW_COST_APARTMENT_VISITOR_GREET)
			rest_button.hide()


func _on_DoneButton_pressed():
	if debug_this: print(self.name + "._on_DoneButton_pressed")
	var travel_path_tile_map: TileMap = get_node_or_null("/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap")
	var owner_name = owner.name
	
	match owner_name:
		"Scene01":
			signals_manager.emit_signal("scene_change", self.name, owner_name, global_data.SCENE_STATE.HIDE)
			signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(SCENE_01_EXIT))
		"Scene02":
			signals_manager.emit_signal("scene_change", self.name, owner_name, global_data.SCENE_STATE.HIDE)
			signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(SCENE_02_EXIT))
		"Scene11":
			signals_manager.emit_signal("scene_change", self.name, owner_name, global_data.SCENE_STATE.HIDE)
			signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(SCENE_11_EXIT))
		null:
			if debug_this: print(self.name + ".null")
			
	signals_manager.emit_signal("on_done_clicked", self.name)


func _on_WorkButton_pressed():
	if debug_this: print(self.name + "._on_DoneButton_pressed")
	signals_manager.emit_signal("_on_WorkButton_pressed", self.name + " " + owner.name)


func _on_RestButton_pressed():
	if debug_this: print(self.name + "._on_RestButton_pressed")
	if global_data.get_rand_between(0,3) == 3:
		signals_manager.emit_signal("on_rest_button_pressed", self.name, {"happiness_increase": 1, "time_used": global_data.REST_TIME_CONSUMED} )
	else:
		signals_manager.emit_signal("on_rest_button_pressed", self.name, {"happiness_increase": 0, "time_used": global_data.REST_TIME_CONSUMED} )
		
