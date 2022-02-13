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
	
	scene_01_node.hide()
	scene_02_node.hide()
	scene_03_node.hide()
	scene_04_node.hide()
	scene_05_node.hide()
	scene_06_node.hide()
	scene_07_node.hide()
	scene_08_node.hide()
	scene_09_node.hide()
	scene_10_node.hide()
	scene_11_node.hide()
	scene_12_node.hide()
	scene_13_node.hide()
	
	scene_01_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_02_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_03_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_04_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_05_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_06_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_07_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_08_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_09_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_10_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_11_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_12_area2d.connect("location_entered_present_scene", self, "present_location")
	scene_13_area2d.connect("location_entered_present_scene", self, "present_location")
	
	signals_manager.connect("player_time_up", self, "hide_scenes")
	
func hide_scenes():
	scene_01_node.hide()
	scene_02_node.hide()
	scene_03_node.hide()
	scene_04_node.hide()
	scene_05_node.hide()
	scene_06_node.hide()
	scene_07_node.hide()
	scene_08_node.hide()
	scene_09_node.hide()
	scene_10_node.hide()
	scene_11_node.hide()
	scene_12_node.hide()
	scene_13_node.hide()


func present_location(scene: Area2D):
	if debug_this: print(self.name + ".present_location ", scene)
	emit_signal("disable_location_buttons")
	
	match scene:
		scene_01_area2d:
			if debug_this: print(self.name + ".match scene_01_area2d show")			
			scene_01_node.show()
		scene_02_area2d:
			if debug_this: print(self.name + ".match scene_02_area2d show")			
			scene_02_node.show()
		scene_03_area2d:
			if debug_this: print(self.name + ".match scene_03_area2d show")			
			scene_03_node.show()
		scene_04_area2d:
			if debug_this: print(self.name + ".match scene_04_area2d show")			
			scene_04_node.show()
		scene_05_area2d:
			if debug_this: print(self.name + ".match scene_05_area2d show")			
			scene_05_node.show()
		scene_06_area2d:
			if debug_this: print(self.name + ".match scene_06_area2d show")			
			scene_06_node.show()
		scene_07_area2d:
			if debug_this: print(self.name + ".match scene_07_area2d show")			
			scene_07_node.show()
		scene_08_area2d:
			if debug_this: print(self.name + ".match scene_08_area2d show")			
			scene_08_node.show()
		scene_09_area2d:
			if debug_this: print(self.name + ".match scene_09_area2d show")			
			scene_09_node.show()
		scene_10_area2d:
			if debug_this: print(self.name + ".match scene_10_area2d show")			
			scene_10_node.show()
		scene_11_area2d:
			if debug_this: print(self.name + ".match scene_11_area2d show")			
			scene_11_node.show()
		scene_12_area2d:
			if debug_this: print(self.name + ".match scene_12_area2d show")			
			scene_12_node.show()
		scene_13_area2d:
			if debug_this: print(self.name + ".match scene_13_area2d show")			
			scene_13_node.show()
		
	
