CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(2000) NOT NULL,
        img VARCHAR(500) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS favorites(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE favorites;

DROP TABLE ingredients;

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        'Homemade Spaghetti',
        'Cook duh pasda, cook deh sawce, mix it in a bowel, and WALLAH',
        'https://images.unsplash.com/photo-1621996346565-e3dbc646d9a9?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8cGFzdGF8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60',
        'Dinner',
        '65271b81e57f826489d44109'
    );

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        'Spicy Ramen',
        'Get a pan, add all broth ingredients, cook for 15mins, add meat, veggies, mushrooms, seasoning, oil, cook for 20 more mins, ETT',
        'https://images.unsplash.com/photo-1623341214825-9f4f963727da?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8cmFtZW58ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60',
        'Dinner',
        '65271b81e57f826489d44109'
    );

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        'Begs and Achin',
        'Throw bacon violently into the pan, gently whisk eggs. Cook bacon until desired crispiness. Put on plate with paper towel to absorb fat. Heat up egg pan to high heat with oil. Pour in eggs, stir constantly until the egg mixture does not shine anymore. Serve and eat!',
        'https://images.unsplash.com/photo-1606851094291-6efae152bb87?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8ZWdncyUyMGFuZCUyMGJhY29ufGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60',
        'Breakfast',
        '65271b81e57f826489d44109'
    );

INSERT INTO
    ingredients(
        name,
        quantity,
        creatorId,
        recipeId
    )
VALUES (
        'chocolate',
        20,
        '65271b81e57f826489d44109',
        79
    )

INSERT INTO
    ingredients(
        name,
        quantity,
        creatorId,
        recipeId
    )
VALUES (
        'smellies',
        1,
        '65271b81e57f826489d44109',
        79
    )

SELECT * FROM recipes;

SELECT * FROM recipes JOIN accounts;

SELECT *
FROM recipes rec
    JOIN accounts act ON act.id = rec.creatorId;