extends Node2D

# const Player = preload("res://src/Player.gd")

const Job = preload("res://src/Job.gd")

onready var tm = get_node("/root/TextManager")

export var SCENE03_JOBS_COMPANY = "Z Mart Discount Store"
export var SCENE03_JOBS_1 = "Clerk"
export var SCENE03_JOBS_2 = "Assistmant Manager"
export var SCENE03_JOBS_3 = "Manager"

export var SCENE04_JOBS_COMPANY = "Monolith Burger"
export var SCENE04_JOBS_1 = "Cook"
export var SCENE04_JOBS_2 = "Clerk"
export var SCENE04_JOBS_3 = "Assistant Manager"
export var SCENE04_JOBS_4 = "Manager"

export var SCENE05_JOBS_COMPANY = "QT Clothing"
export var SCENE05_JOBS_1 = "Sales Person"
export var SCENE05_JOBS_2 = "Assistant Manager"
export var SCENE05_JOBS_3 = "Manager"

export var SCENE06_JOBS_COMPANY = "Socket City"
export var SCENE06_JOBS_1 = "Sales Person"
export var SCENE06_JOBS_2 = "Electronics Repair"
export var SCENE06_JOBS_3 = "Manager"

export var SCENE07_JOBS_COMPANY = "Hi-Tech University"
export var SCENE07_JOBS_1 = "Janitor"
export var SCENE07_JOBS_2 = "Teacher"
export var SCENE07_JOBS_3 = "Professor"

export var SCENE09_JOBS_COMPANY = "Factory"
export var SCENE09_JOBS_1 = "Janitor"
export var SCENE09_JOBS_2 = "Assembly Worker"
export var SCENE09_JOBS_3 = "Secretary"
export var SCENE09_JOBS_4 = "Machinist's Helper"
export var SCENE09_JOBS_5 = "Executive Secretary"
export var SCENE09_JOBS_6 = "Machinist"
export var SCENE09_JOBS_7 = "Department Manager"
export var SCENE09_JOBS_8 = "Engineer"
export var SCENE09_JOBS_9 = "General Manager"

export var SCENE10_JOBS_COMPANY = "Bank"
export var SCENE10_JOBS_1 = "Janitor"
export var SCENE10_JOBS_2 = "Teller"
export var SCENE10_JOBS_3 = "Assistant Manager"
export var SCENE10_JOBS_4 = "Manager"
export var SCENE10_JOBS_5 = "Investment Broker"

export var SCENE11_JOBS_COMPANY = "Black's Market"
export var SCENE11_JOBS_1 = "Janitor"
export var SCENE11_JOBS_2 = "Checker"
export var SCENE11_JOBS_3 = "Butcher"
export var SCENE11_JOBS_4 = "Assistant Manager"
export var SCENE11_JOBS_5 = "Manager"

export var SCENE13_JOBS_COMPANY = "Rental Office"
export var SCENE13_JOBS_1 = "Grounds Keeper"
export var SCENE13_JOBS_2 = "Apartment Manager"

export var NONE = "None"

export var jobs: Array

onready var signals_manager = get_node("/root/SignalsManager")
onready var global_data = get_node("/root/GlobalData")

var debug_this = true


func _init():
	self.jobs = [
		preload("Job.gd").new(99, "Scene01", NONE, NONE, 0, "None", 0, true), 
		
		preload("Job.gd").new(0, "Scene03", SCENE03_JOBS_COMPANY, self.SCENE03_JOBS_1, 3, "None", 0, true), 
		preload("Job.gd").new(1, "Scene03", SCENE03_JOBS_COMPANY, self.SCENE03_JOBS_2, 5, "None", 10, true),
		preload("Job.gd").new(2, "Scene03", SCENE03_JOBS_COMPANY, self.SCENE03_JOBS_3, 6, "None", 20, true),

		preload("Job.gd").new(3, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_1, 3, "None", 0, true),
		preload("Job.gd").new(4, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_2, 4, "None", 0, true),
		preload("Job.gd").new(5, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_3, 5, "None", 10, true),
		preload("Job.gd").new(6, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_4, 6, "None", 20, true),

		preload("Job.gd").new(7, "Scene05", SCENE05_JOBS_COMPANY, self.SCENE05_JOBS_1, 6, "None", 0, true), 
		preload("Job.gd").new(8, "Scene05", SCENE05_JOBS_COMPANY, self.SCENE05_JOBS_2, 8, "None", 10, true),
		preload("Job.gd").new(9, "Scene05", SCENE05_JOBS_COMPANY, self.SCENE05_JOBS_3, 10, "None", 20, true),

		preload("Job.gd").new(10, "Scene06", SCENE06_JOBS_COMPANY, self.SCENE06_JOBS_1, 4, "None", 0, true), 
		preload("Job.gd").new(11, "Scene06", SCENE06_JOBS_COMPANY, self.SCENE06_JOBS_2, 9, "None", 10, true),
		preload("Job.gd").new(12, "Scene06", SCENE06_JOBS_COMPANY, self.SCENE06_JOBS_3, 12, "None", 20, true),

		preload("Job.gd").new(13, "Scene07", SCENE07_JOBS_COMPANY, self.SCENE07_JOBS_1, 3, "None", 0, true), 
		preload("Job.gd").new(14, "Scene07", SCENE07_JOBS_COMPANY, self.SCENE07_JOBS_2, 9, "None", 10, true),
		preload("Job.gd").new(15, "Scene07", SCENE07_JOBS_COMPANY, self.SCENE07_JOBS_3, 18, "None", 20, true),

		preload("Job.gd").new(16, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_1, 6, "None", 0, true), 
		preload("Job.gd").new(17, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_2, 7, "None", 5, true),
		preload("Job.gd").new(18, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_3, 8, "None", 10, true),
		preload("Job.gd").new(19, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_4, 9, "None", 15, true), 
		preload("Job.gd").new(20, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_5, 16, "None", 20, true),
		preload("Job.gd").new(21, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_6, 17, "None", 25, true),
		preload("Job.gd").new(22, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_7, 19, "None", 30, true), 
		preload("Job.gd").new(23, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_8, 20, "None", 35, true),
		preload("Job.gd").new(24, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_9, 22, "None", 40, true),

		preload("Job.gd").new(25, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_1, 5, "None", 0, true), 
		preload("Job.gd").new(24, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_2, 9, "None", 10, true),
		preload("Job.gd").new(25, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_3, 12, "None", 20, true),
		preload("Job.gd").new(26, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_4, 17, "None", 30, true), 
		preload("Job.gd").new(27, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_5, 19, "None", 40, true),

		preload("Job.gd").new(28, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_1, 4, "None", 0, true), 
		preload("Job.gd").new(29, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_2, 7, "None", 0, true),
		preload("Job.gd").new(30, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_3, 10, "None", 10, true),
		preload("Job.gd").new(31, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_4, 13, "None", 20, true), 
		preload("Job.gd").new(32, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_5, 16, "None", 25, true),

		preload("Job.gd").new(33, "Scene13", SCENE13_JOBS_COMPANY, self.SCENE13_JOBS_1, 5, "None", 0, true), 
		preload("Job.gd").new(34, "Scene13", SCENE13_JOBS_COMPANY, self.SCENE13_JOBS_2, 7, "None", 10, true),

]

func _ready():
	if debug_this: print(self.name + "._ready")	
	if debug_this: print(self.name + ".jobs count: ", jobs.size())
	signals_manager.connect("update_job_economy", self, "update_jobs_economy")
	signals_manager.connect("job_manager_check_get_job", self, "can_get_job")
	signals_manager.connect("work_button_clicked", self, "work_job")


func work_job(caller):
	if debug_this: print(self.name + ".work_job", " caller: ", caller)	
	var player = global_data.get_current_player()
	# if players turn time plus a single time to work is less than the global time, do normal work cost
	if (player.turn_time_used + (global_data.MAX_TIME / global_data.WORK_JOB_COST)) < global_data.MAX_TIME:
		player.current_money += player.current_job.base_salary * global_data.WORK_JOB_MULTIPLYER
		player.turn_time_used += (global_data.MAX_TIME / global_data.WORK_JOB_COST)
	# else we calculate the amount of time that can be worked and do a smaller salery
	else:
		var time_left = global_data.MAX_TIME - player.turn_time_used
		player.current_money += player.current_job.base_salary * ((time_left / (global_data.MAX_TIME / global_data.WORK_JOB_COST)) * 10)
		player.turn_time_used += global_data.MAX_TIME / global_data.WORK_JOB_COST
	
	player.current_job_experience += 1
	signals_manager.emit_signal("player_data_updated", self.name)
	


func update_jobs_economy(caller):
	if debug_this: print(self.name + ".update_jobs_economy", " caller: ", caller)	
	var adjusted = (global_data.econ_values.back() as float / 100 as float)

	for job in self.jobs:
		job.base_salary = (job.base_salary * adjusted) as int
		if (global_data.get_rand_between(1, 10)) < 3:
			job.job_available = false
		else:
			job.job_available = true
			
				

func can_get_job(caller, job: Job):
	if debug_this: print(self.name + ".can_get_job", " caller: ", caller)
	
	var can_get_the_job = false
	var player = global_data.get_current_player()

	if player.current_job == job:
		signals_manager.emit_signal("change_player_job", self.name, job)
		signals_manager.emit_signal("job_results_container_update", tm.GOT_THE_JOB)
		return

	for key in player.education.keys():
		if key == job.required_degree && player.education[key] > 13:
			can_get_the_job = true
			break	

	if job.job_available != true:
		signals_manager.emit_signal("job_results_container_update", tm.NO_JOB_AVAILABLE)
		return	

	if player.work_exp < job.required_work_exp:
		signals_manager.emit_signal("job_results_container_update", tm.NOT_ENOUGH_EXPERIENCE)
		return

	if can_get_the_job:
		signals_manager.emit_signal("change_player_job", self.name, job)
		signals_manager.emit_signal("job_results_container_update", tm.GOT_THE_JOB)
	
