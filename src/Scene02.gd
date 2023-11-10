extends Node2D

@onready var signals_manager = get_node_or_null("/root/SignalsManager")
@onready var global_data = get_node("/root/GlobalData")
@onready var info_label_box = get_node("VBoxContainer/HBoxContent/HBoxText/InfoLabelBox")
@onready var text_manager = get_node("/root/TextManager")

var THIS_SCENE_EXIT = Vector2(42,12)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")
	signals_manager.connect("scene_change", Callable(self, "change_scene_to_file"))
	setup_scene()
		
		
func setup_scene():
	if debug_this: print(self.name, ".setup_scene()")
	if owner == null:
		self.show()
		info_label_box.text = text_manager.get_random_message(text_manager.PAWN_SHOP_GREET)		
	else:
		self.hide()


func change_scene_to_file(caller, scene_name, state):
	if debug_this: print(self.name + ".change_scene_to_file() caller ", caller, " state ", state, " scene_name ", scene_name)	
	if scene_name == self.name:
		if state == global_data.SCENE_STATE.HIDE:
			self.hide()
		else:
			self.show()
			info_label_box.text = text_manager.get_random_message(text_manager.PAWN_SHOP_GREET)
			
			
func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_local(THIS_SCENE_EXIT))
	signals_manager.emit_signal("on_done_clicked", self.name)
	self.hide()
