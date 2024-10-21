package di;

import data.parsers.Parsers;
import presentation.commands.*;

public record Menu(
	CatalogCommands catalogCommands,
	ArticleCommands articleCommands,
	ContentCommands contentCommands,
	Parsers parsers
) {}
