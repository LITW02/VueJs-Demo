var x = new Vue({
    el: '#main',
    data: {
        message: '',
        numbers: []
    },

    methods: {
        reverse: function() {
            this.message = reverseString(this.message);
        },

        addNumber: function() {
            var num = Math.floor((Math.random() * 1000) + 1);
            this.numbers.push(num);
        },

        sort: function() {
            this.numbers.sort();
        }
    }
});

function reverseString(str) {
    return str.split('').reverse().join('');
}