extends Node2D

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
export var SCENE05_JOBS_2 = "Assistmant Manager"
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

export var jobs: Array

var debug_this = true

func _init():
	jobs = [
		preload("Job.gd").new(0, "Scene03", SCENE03_JOBS_COMPANY, self.SCENE03_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(1, "Scene03", SCENE03_JOBS_COMPANY, self.SCENE03_JOBS_2, 5, [], 10, true),
		preload("Job.gd").new(2, "Scene03", SCENE03_JOBS_COMPANY, self.SCENE03_JOBS_3, 5, [], 20, true),

		preload("Job.gd").new(3, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_1, 5, [], 20, true),
		preload("Job.gd").new(4, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_2, 5, [], 20, true),
		preload("Job.gd").new(5, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_3, 5, [], 20, true),
		preload("Job.gd").new(6, "Scene04", SCENE04_JOBS_COMPANY, self.SCENE04_JOBS_4, 5, [], 20, true),

		preload("Job.gd").new(7, "Scene05", SCENE05_JOBS_COMPANY, self.SCENE05_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(8, "Scene05", SCENE05_JOBS_COMPANY, self.SCENE05_JOBS_2, 5, [], 10, true),
		preload("Job.gd").new(9, "Scene05", SCENE05_JOBS_COMPANY, self.SCENE05_JOBS_3, 5, [], 20, true),

		preload("Job.gd").new(10, "Scene06", SCENE06_JOBS_COMPANY, self.SCENE06_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(11, "Scene06", SCENE06_JOBS_COMPANY, self.SCENE06_JOBS_2, 5, [], 10, true),
		preload("Job.gd").new(12, "Scene06", SCENE06_JOBS_COMPANY, self.SCENE06_JOBS_3, 5, [], 20, true),

		preload("Job.gd").new(13, "Scene07", SCENE07_JOBS_COMPANY, self.SCENE07_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(14, "Scene07", SCENE07_JOBS_COMPANY, self.SCENE07_JOBS_2, 5, [], 10, true),
		preload("Job.gd").new(15, "Scene07", SCENE07_JOBS_COMPANY, self.SCENE07_JOBS_3, 5, [], 20, true),

		preload("Job.gd").new(16, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(17, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_2, 5, [], 10, true),
		preload("Job.gd").new(18, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_3, 5, [], 20, true),
		preload("Job.gd").new(19, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_4, 5, [], 0, true), 
		preload("Job.gd").new(20, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_5, 5, [], 10, true),
		preload("Job.gd").new(21, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_6, 5, [], 20, true),
		preload("Job.gd").new(22, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_7, 5, [], 0, true), 
		preload("Job.gd").new(23, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_8, 5, [], 10, true),
		preload("Job.gd").new(24, "Scene09", SCENE09_JOBS_COMPANY, self.SCENE09_JOBS_9, 5, [], 20, true),

		preload("Job.gd").new(25, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(24, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_2, 5, [], 10, true),
		preload("Job.gd").new(25, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_3, 5, [], 20, true),
		preload("Job.gd").new(26, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_4, 5, [], 0, true), 
		preload("Job.gd").new(27, "Scene10", SCENE10_JOBS_COMPANY, self.SCENE10_JOBS_5, 5, [], 10, true),

		preload("Job.gd").new(28, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(29, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_2, 5, [], 10, true),
		preload("Job.gd").new(30, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_3, 5, [], 20, true),
		preload("Job.gd").new(31, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_4, 5, [], 0, true), 
		preload("Job.gd").new(32, "Scene11", SCENE11_JOBS_COMPANY, self.SCENE11_JOBS_5, 5, [], 10, true),

		preload("Job.gd").new(33, "Scene13", SCENE13_JOBS_COMPANY, self.SCENE13_JOBS_1, 5, [], 0, true), 
		preload("Job.gd").new(34, "Scene13", SCENE13_JOBS_COMPANY, self.SCENE13_JOBS_2, 5, [], 10, true),

]

func _ready():
	if debug_this: print(self.name + "._ready")	

	for j in jobs:
		print(j.to_string())
	pass # Replace with function body.
