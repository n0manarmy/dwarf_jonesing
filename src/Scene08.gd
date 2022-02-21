extends Node2D

onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var tm = get_node_or_null("/root/TextManager")
onready var main_menu_container = get_node("TextBackground/VBoxContainer/MainMenuContainer")

var THIS_SCENE_EXIT = Vector2(27,43)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	pass # Replace with function body.
	
	
func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("update_position", travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
	signals_manager.emit_signal("on_done_clicked")
	self.hide()

func hide_menus():
	if debug_this: print(self.name + ".hide_menus")
	main_menu_container.visible = false

func present_jobs(label, jobs):
	if debug_this: print(self.name + ".present_jobs")


func scene_03():
	if debug_this: print(self.name + ".z_mart_discount")
	hide_menus()
	present_jobs(tm.Z_MART_JOBS_LABEL)

func scene_04():
	if debug_this: print(self.name + ".monolith_burger")

		
func scene_05():
	if debug_this: print(self.name + ".qt_clothing")


func scene_06():
	if debug_this: print(self.name + ".socket_city_appliance")

		
func scene_07():
	if debug_this: print(self.name + ".hi_tech_university")


func scene_09():
	if debug_this: print(self.name + ".factory")


func scene_10():
	if debug_this: print(self.name + ".bank")

		
func scene_11():
	if debug_this: print(self.name + ".blacks_market")


func scene_13():
	if debug_this: print(self.name + ".rent_office")
