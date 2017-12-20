describe("Image portal tests", function() {
    beforeEach(function () {
        cy.TestSetup();
    });

    context("Navigation", function () {
        it("contains home page", function () {
            cy.get(".home-page");
        });

        it("contains department image", function() {
            cy.get(".department-image");
        });
    });

    context("Department images", function() {
        beforeEach(function() {
            cy.get(".department-image").click();
        });

        it("Contains department selector", function() {
            cy.get("select.department-selector");
        });
    });

});