class Person
	attr_reader :name
	attr_reader :country

	def initialize(name, country)
		@name = name
		@country = country
	end

	def SayName
		puts @name
	end
end

Vip.SayName