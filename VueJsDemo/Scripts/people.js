new Vue({
    el: '#app',
    data: {
        people: [],
        modalPerson: {
            id: 0,
            firstName: '',
            lastName: '',
            age: ''
        },
        editMode: false
    },

    ready: function () {
        this.loadPeople();
    },

    methods: {
        loadPeople: function() {
            var self = this;
            $.get('/people/getall', function (people) {
                self.people = people;
            });
        },

        addClick: function () {
            this.editMode = false;
            $(".modal").modal();
        },

        saveClick: function() {
            var self = this;
            $.post('/people/add', this.modalPerson, function() {
                self.loadPeople();
                self.modalPerson = {
                    id: 0,
                    firstName: '',
                    lastName: '',
                    age: ''
                }
                $(".modal").modal('hide');
            });
        },

        editClick: function (person) {
            this.editMode = true;
            this.modalPerson.id = person.Id;
            this.modalPerson.firstName = person.FirstName;
            this.modalPerson.lastName = person.LastName;
            this.modalPerson.age = person.Age;
            $(".modal").modal();
        },

        updateClick: function() {
            var self = this;
            $.post('/people/update', this.modalPerson, function() {
                self.loadPeople();
                self.modalPerson = {
                    id: 0,
                    firstName: '',
                    lastName: '',
                    age: ''
                }
                $(".modal").modal('hide');
            });
        },

        deletePerson: function(id) {
            var self = this;
            $.post('/people/delete', { id: id }, function() {
                self.loadPeople();
            });
        }

    }
});