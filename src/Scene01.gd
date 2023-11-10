extends Node2D

@onready var signals_manager = get_node_or_null("/root/SignalsManager")
@onready var im = get_node("/root/ItemManager")
@onready var global_data = get_node("/root/GlobalData")
@onready var text_manager = get_node("/root/TextManager")
@onready var info_label_box: Label = get_node("VBoxContainer/HBoxContainer/InfoLabelBox")

var THIS_SCENE_EXIT = Vector2(31, 11)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	signals_manager.connect("scene_change", Callable(self, "change_scene_to_file"))
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
			self.show()
			var player = global_data.get_current_player()
			if player.possessions.has(im.get_item(im.ItemRef.LOW_COST_RENT)):
				info_label_box.text = text_manager.get_random_message(text_manager.LOW_COST_APARTMENT_HOME_GREET)
			else:
				info_label_box.text = text_manager.get_random_message(text_manager.LOW_COST_APARTMENT_VISITOR_GREET)
