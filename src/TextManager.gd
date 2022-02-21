extends Node

onready var global_data = get_node("/root/GlobalData")

export var NEW_LOW_COST_APARTMENT = "We'll get you a key right away! And we'll even scrub that spot on the carpet!!"
export var RENTING_LOW_COST_APARTMENT = "You're already renting a Low Cost Apartment!"
export var RENTING_LE_SECURITY_APARTMENT = "But Sir! We have already prepared your bubble bath in your Le Security apartment!"
export var NEW_LE_SECURITY_APARTMENT = "Please step this way so you can know what money smells like!"
export var RENT_PAYED = "Thank you for paying your rent! Now we won't have to send the dogs."
export var NO_MONEY_TO_PAY_RENT = "You ain't got no monies!"
export var RENTAL_OFFICE_CLOSED = "Closed!"
export var SECURITY_DEPOSIT_PAYED_FIRST = "You must pay your security deposit for the month first!"
export var EXTEND_RENT = "Sure you can pay your rent next week!"
export var REJECTED_EXTENDING_RENT = "Sorry but I need you to pay now."

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

export var RENTAL_OFFICE_OPEN = ["Welcome to another beautiful day at your caring Rental Office", "Hi! Finally here to pay the rent?!", "Hello? Oh Hi! Got my monies?!"]
export var LOW_COST_APARTMENT_HOME_GREET = ["Ahh, home sweet BLAAARGH!!", "Oh! Hey! There's that banana I've been missing!", "Oh...rats!"]
export var LOW_COST_APARTMENT_VISITOR_GREET = ["Well that's just something special! Vomit colored doormats?", "I wonder why they call it Low Cost...ooooh!", "Oh...rats!"]

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func get_random_message(val):
	return val[global_data.rng.randi_range(0, val.size() - 1)]