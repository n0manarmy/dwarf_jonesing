extends Node2D


var THIS_SCENE_EXIT = Vector2(20,12)
var LOW_COST_BASE_RENT_VALUE = 325
var LE_SECURITY_BASE_RENT_VALUE = 600

onready var pay_rent_button: Button = get_node("TextBackground/ActionsContainer/PayRentContainer/PayRentButtonContainer/Button")
onready var rent_low_cost_button: Button = get_node("TextBackground/ActionsContainer/LowCostContainer/LowCostButtonContainer/Button")
onready var rent_le_security_button: Button = get_node("TextBackground/ActionsContainer/LeSecurityContainer/LeSecurityButtonContainer/Button")
onready var info_label_box: Label = get_node("TextBackground/InfoLabelBox")
onready var actions_container: VBoxContainer = get_node("TextBackground/ActionsContainer")
onready var work_button: Button = get_node("TextBackground/WorkButton")
onready var global_data = get_node("/root/GlobalData")
onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var im = get_node("/root/InventoryManager")
onready var scene_label = get_node("TextBackground/NameLabel")

onready var text_manager = get_node("/root/TextManager")
onready var job_manager = get_node("/root/JobManager")

onready var just_payed = false

var player
var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	self.player = global_data.get_current_player()
	if self.player.current_job.company == job_manager.SCENE13_JOBS_COMPANY:
		work_button.visible = true
	else:
		work_button.visible = false
	
	if (global_data.game_rounds % 4 == 0 && global_data.game_rounds != 0) || self.player.rent_extended > 0:
		show_rental_office()
	else:
		hide_rental_office()


func hide_rental_office():
	if debug_this: print(self.name + ".hide_rental_office")	

	actions_container.visible = false
	info_label_box.text = text_manager.RENTAL_OFFICE_CLOSED


func show_rental_office():
	if debug_this: print(self.name + ".show_rental_office")	
	
	actions_container.visible = true
	pay_rent_button.set_text(str(player.current_rent))

	# info_label_box.text = text_manager.RENTAL_OFFICE_OPEN[global_data.rng.randi_range(0, text_manager.RENTAL_OFFICE_OPEN.size() - 1)]
	info_label_box.text = text_manager.get_random_message(text_manager.RENTAL_OFFICE_OPEN)

	var adjust_rent = global_data.adjust_for_economy(LOW_COST_BASE_RENT_VALUE)
	rent_low_cost_button.set_text(str(adjust_rent))
	
	adjust_rent = global_data.adjust_for_economy(LE_SECURITY_BASE_RENT_VALUE)
	rent_le_security_button.set_text(str(adjust_rent))


func ask_for_more_time():
	if debug_this: print(self.name + ".ask_for_more_time")	

	if self.player.rent_due <= self.player.current_rent && self.player.rent_extended < 2:
		info_label_box.text = text_manager.EXTEND_RENT

	else:
		info_label_box.text = text_manager.REJECT_EXTENDING_RENT


func pay_rent_clicked():
	if debug_this: print(self.name + ".pay_rent_clicked")
	if self.player.wealth >= self.player.current_rent:
		self.player.wealth = self.player.wealth - self.player.current_rent
		self.player.rent_due = self.player.rent_due - self.player.current_rent
		pay_rent_button.set_text(str(self.player.rent_due))
		info_label_box.text = text_manager.RENT_PAYED
		self.player.rent_extended = 0
		if just_payed == true:
			just_payed = false;
		signals_manager.emit_signal("player_data_updated")
		if debug_this: print(self.name + ".self.player.rent_due: ", self.player.rent_due)
	else:
		info_label_box.text = text_manager.NO_MONEY_TO_PAY_RENT


func rent_low_cost_apartment():
	if debug_this: print(self.name + ".rent_low_cost_apartment")
	if self.player.possessions.has(im.LOW_COST_APARTMENT.keys()[0]):
		info_label_box.text = text_manager.RENTING_LOW_COST_APARTMENT
	elif just_payed == true:
		info_label_box.text = text_manager.SECURITY_DEPOSIT_PAYED_FIRST
	else:
		info_label_box.text = text_manager.NEW_LOW_COST_APARTMENT
		self.player.possessions.erase(im.LE_SECURITY_APARTMENT.keys()[0])
		self.player.possessions[im.LOW_COST_APARTMENT.keys()[0]] = im.LOW_COST_APARTMENT.values()[0]
		just_payed = true
		self.player.rent_extended = 0



func rent_le_security_apartment():
	if debug_this: print(self.name + ".rent_le_security_apartment")
	
	if self.player.possessions.has(im.LE_SECURITY_APARTMENT.keys()[0]):
		info_label_box.text = text_manager.RENTING_LE_SECURITY_APARTMENT
	elif just_payed == true:
		info_label_box.text = text_manager.SECURITY_DEPOSIT_PAYED_FIRST
	else:
		self.player.possessions.erase(im.LOW_COST_APARTMENT.keys()[0])
		self.player.possessions[im.LE_SECURITY_APARTMENT.keys()[0]] = im.LE_SECURITY_APARTMENT.values()[0]
		info_label_box.text = text_manager.NEW_LE_SECURITY_APARTMENT
		just_payed = true
		self.player.rent_extended = 0


func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
	signals_manager.emit_signal("on_done_clicked", self.name)
	self.hide()


func on_work_clicked():
	if debug_this: print(self.name + ".on_work_clicked")

	pass # Replace with function body.
