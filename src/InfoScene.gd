extends Node2D

signal disable_location_buttons

onready var scene_01_node = get_node_or_null("Scene01")
onready var scene_02_node = get_node_or_null("Scene02")
onready var scene_03_node = get_node_or_null("Scene03")
onready var scene_04_node = get_node_or_null("Scene04")
onready var scene_05_node = get_node_or_null("Scene05")
onready var scene_06_node = get_node_or_null("Scene06")
onready var scene_07_node = get_node_or_null("Scene07")
onready var scene_08_node = get_node_or_null("Scene08")
onready var scene_09_node = get_node_or_null("Scene09")
onready var scene_10_node = get_node_or_null("Scene10")
onready var scene_11_node = get_node_or_null("Scene11")
onready var scene_12_node = get_node_or_null("Scene12")
onready var scene_13_node = get_node_or_null("Scene13")

onready var scene_01_area2d = get_node_or_null("../WalkingPath/Scene01")
onready var scene_02_area2d = get_node_or_null("../WalkingPath/Scene02")
onready var scene_03_area2d = get_node_or_null("../WalkingPath/Scene03")
onready var scene_04_area2d = get_node_or_null("../WalkingPath/Scene04")
onready var scene_05_area2d = get_node_or_null("../WalkingPath/Scene05")
onready var scene_06_area2d = get_node_or_null("../WalkingPath/Scene06")
onready var scene_07_area2d = get_node_or_null("../WalkingPath/Scene07")
onready var scene_08_area2d = get_node_or_null("../WalkingPath/Scene08")
onready var scene_09_area2d = get_node_or_null("../WalkingPath/Scene09")
onready var scene_10_area2d = get_node_or_null("../WalkingPath/Scene10")
onready var scene_11_area2d = get_node_or_null("../WalkingPath/Scene11")
onready var scene_12_area2d = get_node_or_null("../WalkingPath/Scene12")
onready var scene_13_area2d = get_node_or_null("../WalkingPath/Scene13")

onready var global_data = get_node_or_null("/root/GlobalData")
onready var signals_manager = get_node_or_null("/root/SignalsManager")

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	
	hide_scenes(self.name)
	
	signals_manager.connect("location_entered_present_scene", self, "present_location")
	signals_manager.connect("player_time_up", self, "hide_scenes")
	
func hide_scenes(caller):
	if debug_this: print(self.name + ".hide_scenes", " caller: ", caller)

	signals_manager.emit_signal("scene_change", self.name, "Scene01", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene02", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene03", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene04", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene05", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene06", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene07", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene08", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene09", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene10", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene11", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene12", global_data.SCENE_STATE.HIDE)
	signals_manager.emit_signal("scene_change", self.name, "Scene13", global_data.SCENE_STATE.HIDE)


func present_location(caller, scene: Area2D):
	if debug_this: print(self.name + ".present_location ", scene, " caller: ", caller)
	signals_manager.emit_signal("disable_location_buttons", self.name, true)
	
	match scene:
		scene_01_area2d:
			if debug_this: print(self.name + ".match scene_01_area2d show")			
			if !scene_01_node.is_inside_tree():
				scene_01_node._ready()
			scene_01_node.show()
		scene_02_area2d:
			if debug_this: print(self.name + ".match scene_02_area2d show")			
			if !scene_02_node.is_inside_tree():
				scene_02_node._ready()
			scene_02_node.show()
		scene_03_area2d:
			if debug_this: print(self.name + ".match scene_03_area2d show")			
			if !scene_03_node.is_inside_tree():
				scene_03_node._ready()
			scene_03_node.show()
		scene_04_area2d:
			if debug_this: print(self.name + ".match scene_04_area2d show")			
			if !scene_04_node.is_inside_tree():
				scene_04_node._ready()
			scene_04_node.show()
		scene_05_area2d:
			if debug_this: print(self.name + ".match scene_05_area2d show")			
			if !scene_05_node.is_inside_tree():
				scene_05_node._ready()
			scene_05_node.show()
		scene_06_area2d:
			if debug_this: print(self.name + ".match scene_06_area2d show")			
			if !scene_06_node.is_inside_tree():
				scene_06_node._ready()
			scene_06_node.show()
		scene_07_area2d:
			if debug_this: print(self.name + ".match scene_07_area2d show")
			if !scene_07_node.is_inside_tree():
				scene_07_node._ready()
			scene_07_node.show()
		scene_08_area2d:
			if debug_this: print(self.name + ".match scene_08_area2d show")
			if !scene_08_node.is_inside_tree():
				scene_08_node._ready()
			scene_08_node.show()
		scene_09_area2d:
			if debug_this: print(self.name + ".match scene_09_area2d show")			
			if !scene_09_node.is_inside_tree():
				scene_09_node._ready()
			scene_09_node.show()
		scene_10_area2d:
			if debug_this: print(self.name + ".match scene_10_area2d show")			
			if !scene_10_node.is_inside_tree():
				scene_10_node._ready()
			scene_10_node.show()
		scene_11_area2d:
			if debug_this: print(self.name + ".match scene_11_area2d show")			
			if !scene_11_node.is_inside_tree():
				scene_11_node._ready()
			scene_11_node.show()
		scene_12_area2d:
			if debug_this: print(self.name + ".match scene_12_area2d show")			
			if !scene_12_node.is_inside_tree():
				scene_12_node._ready()
			scene_12_node.show()
		scene_13_area2d:
			if debug_this: print(self.name + ".match scene_13_area2d show")
			signals_manager.emit_signal("scene_change", self.name, "Scene13", global_data.SCENE_STATE.SHOW)
			# if !scene_13_node.is_inside_tree():
			# 	scene_13_node._ready()
			# scene_13_node.show()
